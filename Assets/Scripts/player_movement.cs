using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour {
    public float speed = 10.0F;
    public float jumpspeed = 20.0F;
    public float maxfallSpeed = 20.0F;
    public float gravity = 10.0F;

    private Vector3 moveDirection = Vector3.zero;

    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetButton("Run"))
            {
                moveDirection *= speed * 2;
            }
            else
            {
            moveDirection *= speed;
            }
            

            if (Input.GetButton("Jump"))
            {
                if (controller.isGrounded)
                {
                    moveDirection.y = jumpspeed;
                }
            }
        }
        moveDirection.y -= gravity * Time.deltaTime * 5.5F;
        if (moveDirection.y == maxfallSpeed)
        {
            moveDirection.y = maxfallSpeed;
        }
        controller.Move(moveDirection * Time.deltaTime);
    }
}
