using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour
{
    [Tooltip("Movement Values")]
    [SerializeField] float moveSpeed, rotationSpeed, gravityForce, jumpForce;

    [Header("Controls")]
    public string Horizontal2, Vertical2;
    public KeyCode Jump2;



    //Components
    CharacterController cc;
    Animator anim;
    Vector3 moveDirection;
    public Camera cam;

    public bool slowness2;

    public bool boost2;

    public Transform target;

    Vector3 playerVelocity;
    public bool groundedPLayer2;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        groundedPLayer2 = cc.isGrounded;
        if (groundedPLayer2 && playerVelocity.y < 0)
        {
            if (anim.GetBool("Jump2")) anim.SetBool("Jump2", false);
            playerVelocity.y = 0;
        }
        float h = Input.GetAxis("Horizontal2");
        float v = Input.GetAxis("Vertical2");
        Vector3 camh = cam.transform.right;
        Vector3 camv = Vector3.Cross(camh, Vector3.up);

        if (h != 0 || v != 0)
        {
            moveDirection = camh * h + camv * v;
            moveDirection.Normalize();
            cc.Move(moveDirection * moveSpeed * Time.deltaTime);

            anim.SetBool("HasInput2", true);
        }
        else
        {
            anim.SetBool("HasInput2", false);
        }

        // moveDirection.Set(h, 0, v);
        moveDirection.Normalize();

        Quaternion desiredDirection = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredDirection, rotationSpeed);

        Vector3 animationVector = transform.InverseTransformDirection(cc.velocity);

        // cc.Move(moveDirection * moveSpeed * Time.deltaTime);

        anim.SetFloat("HorizontalSpeed2", animationVector.x);
        anim.SetFloat("VirticalSpeed2", animationVector.z);

        ProcessGravity2();
    }
    public void ProcessGravity2()
    {
        if (Input.GetKeyDown(KeyCode.Return) && groundedPLayer2)
        {
            anim.SetBool("Jump2", true);
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravityForce);
        }
        playerVelocity.y += gravityForce * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);
    }
    public void SpeedBoost2()
    {
        moveSpeed = 16;
        Invoke("ReturnSpeed2", 2f);
    }
    public void ReturnSpeed2()
    {
        moveSpeed = 8;
    }
    public void Slow2()
    {
        moveSpeed = 2;
    }
    public void Finish2()
    {
        Debug.Log("Stop2");
        moveSpeed = 8;
        Invoke("FinishSpeed2", 2f);
    }
    public void FinishSpeed2()
    {
        moveSpeed = 0;
    }
   
}