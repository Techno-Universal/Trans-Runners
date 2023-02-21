using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Tooltip("Movement Values")]
    [SerializeField] float moveSpeed, rotationSpeed;

    //Components
    CharacterController cc;
    Animator anim;
    Vector3 moveDirection;
    Camera cam;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim= GetComponentInChildren<Animator>();

        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 camh = cam.transform.right;
        Vector3 camv = Vector3.Cross(camh, Vector3.up);
        moveDirection.Set(h, 0, v);
        moveDirection.Normalize();

        cc.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
