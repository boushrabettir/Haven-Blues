using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float gravity =  9.5f;
    private float velocity = 0f;
    public float speed; 
    public CharacterController controller;
    private bool isGrounded;
    public float jumpHeight = 5f;
    private Vector3 vector;

    // Start is called before the first frame update
    void Start()
    {
        controller.GetComponent<CharacterController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;
        controller.Move((Vector3.right * horizontal + Vector3.left * vertical) * Time.deltaTime);

        if (controller.isGrounded && isGrounded)
        {
            velocity = 0;

        } else
        {
            velocity -= gravity * Time.deltaTime;
            controller.Move(new Vector3(0, velocity, 0));
        }
        
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity += Mathf.Sqrt(jumpHeight * -3.0f * gravity);

        }
    }
}
