using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour
{
    [Tooltip("Movement Values")]
    [SerializeField] float moveSpeed, rotationSpeed, gravityForce, jumpForce;

    [Header("Controls")]
    public string Horizontal1, Vertical1;
    public KeyCode jump1;



    //Components
    CharacterController cc;
    Animator anim;
    Vector3 moveDirection;
    Camera cam;

    public bool slowness2;

    public bool boost2;

    public Transform target;

    Vector3 playerVelocity;
    public bool groundedPLayer;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        groundedPLayer = cc.isGrounded;
        if (groundedPLayer && playerVelocity.y < 0)
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

        moveDirection.Set(h, 0, v);
        moveDirection.Normalize();

        Quaternion desiredDirection = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredDirection, rotationSpeed);

        Vector3 animationVector = transform.InverseTransformDirection(cc.velocity);

        cc.Move(moveDirection * moveSpeed * Time.deltaTime);

        anim.SetFloat("HorizontalSpeed2", animationVector.x);
        anim.SetFloat("VirticalSpeed2", animationVector.z);

        ProcessGravity();
    }
    public void ProcessGravity()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundedPLayer)
        {
            anim.SetBool("Jump2", true);
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravityForce);
        }
        playerVelocity.y += gravityForce * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);
    }
}