using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Photon.Pun;

public class OnlineCharacterMovement : MonoBehaviour
{
    [Header("Movement Values")]
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float gravityForce;
    [SerializeField] float jumpForce;

    //Components
    CharacterController cc;
    Animator anim;
    PhotonView view;

    Vector3 movementDirection;
    Camera cam;

    public Transform target;

    //Gravity and jump
    Vector3 playerVelocity;
    public bool groundedPlayer;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        cam = Camera.main;
        view = GetComponent<PhotonView>();

    }
    private void Awake()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            Debug.Log("P2Assigned");
            SpeedBoostZoneOnline.oCM2 = this;
            SlowZoneOnline.oCM2 = this;
            FinishZoneOnline.c2 = this;
        }
        if (PhotonNetwork.IsMasterClient)
        {
            Debug.Log("P1Assigned");
            SpeedBoostZoneOnline.oCM1 = this;
            SlowZoneOnline.oCM1 = this;
            FinishZoneOnline.c1 = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!view.IsMine) return;

        groundedPlayer = cc.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            if (anim.GetBool("Jump1")) anim.SetBool("Jump1", false);
            playerVelocity.y = 0;
        }
        float h = Input.GetAxis("Horizontal1");
        float v = Input.GetAxis("Vertical1");
        Vector3 camh = cam.transform.right;
        Vector3 camv = Vector3.Cross(camh, Vector3.up);

        if (h != 0 || v != 0)
        {
            movementDirection = camh * h + camv * v;
            movementDirection.Normalize();
            cc.Move(movementDirection * movementSpeed * Time.deltaTime);

            anim.SetBool("HasInput1", true);
        }
        else
        {
            anim.SetBool("HasInput1", false);
        }

        movementDirection.Normalize();

        Quaternion desiredDirection = Quaternion.LookRotation(movementDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredDirection, rotationSpeed);

        Vector3 animationVector = transform.InverseTransformDirection(cc.velocity);

        // cc.Move(moveDirection * moveSpeed * Time.deltaTime);

        anim.SetFloat("HorizontalSpeed1", animationVector.x);
        anim.SetFloat("VirticalSpeed1", animationVector.z);

        ProcessGravity();
       
    }
    public void ProcessGravity()
    {
        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer)
        {
            anim.SetBool("Jump1", true);
            playerVelocity.y += Mathf.Sqrt(jumpForce * -3.0f * gravityForce);
        }
        playerVelocity.y += gravityForce * Time.deltaTime;
        cc.Move(playerVelocity * Time.deltaTime);
    }


    public void SpeedBoostOnline()
    {
        Debug.Log("Speed");
        movementSpeed = 16;
        Invoke("ReturnSpeedOnline", 2f);
    }
    public void ReturnSpeedOnline()
    {
        Debug.Log("Return");
        movementSpeed = 8;
    }
    public void SlowOnline()
    {
        Debug.Log("Slow");
        movementSpeed = 2;
    }
    public void FinishOnline1()
    {
        if (tag == "Player1")
        {
            Debug.Log("Stop1");
            movementSpeed = 8;
            Invoke("FinishSpeedOnline", 2f);
        }
    }
    public void FinishOnline2()
    {
        if (tag == "Player2")
        {
            Debug.Log("Stop2");
            movementSpeed = 8;
            Invoke("FinishSpeedOnline", 2f);
        }
    }
    public void FinishSpeedOnline()
    {
        movementSpeed = 0;
    }

}
