using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public float speed = 8f;
    public float rotSpeed;
    public Animator anim;
    Rigidbody rb;
    PhotonView view;

    Vector3 input;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb = GetComponent<Rigidbody>();
        view = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!view.IsMine) return;

        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        input.Normalize();

        //transform.position += input * speed * Time.deltaTime;

        if (input == Vector3.zero) anim.SetBool("walking", false);
        else anim.SetBool("walking", true);

        //look
        var lookDirection = Quaternion.LookRotation(input, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, lookDirection, rotSpeed);
    }
    private void FixedUpdate()
    {
        if (!view.IsMine) return;
        rb.position += input * speed * Time.deltaTime;
    }

    public void SpeedBoost()
    {
        speed = 16;
        Invoke("ReturnSpeed1", 2f);
    }
    public void ReturnSpeed()
    {
        speed = 8;
    }
    public void Slow()
    {
        speed = 2;
    }
    public void Finish()
    {
        Debug.Log("Stop1");
        speed = 8;
        Invoke("FinishSpeed1", 2f);
    }
    public void FinishSpeed()
    {
        speed = 0;
    }

}
