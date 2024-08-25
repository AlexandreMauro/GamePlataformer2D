using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D PlayerRigibody;
    [Header("Friction")]
    public  Vector2 Friction = new Vector2(.1f,0);
    private Vector2 StopFriction = new Vector2(.1f,0);
    
    [Header("Jump")]
    public float jumpforce;
   [Header("Speed")]
    public float Speed;
    public float RunSpeed;
    private float _currentSpeed;
    
    
    private void Update()
    {
        HandleJump();
        HandleMovements();
    }


    //HorizontalMovements
    private void HandleMovements()
    {

        if(Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = RunSpeed;
        }
        else
        {
            _currentSpeed = Speed;
        }


        if (Input.GetKey(KeyCode.D))
        {
            // PlayerRigibody.MovePosition(PlayerRigibody.position + Velocity * Time.deltaTime);
            PlayerRigibody.velocity = new Vector2(_currentSpeed, PlayerRigibody.velocity.y);


        }
        else if (Input.GetKey(KeyCode.A))
        {
            PlayerRigibody.velocity = new Vector2(-_currentSpeed, PlayerRigibody.velocity.y);
            // PlayerRigibody.MovePosition(PlayerRigibody.position - Velocity * Time.deltaTime);
        }



     

            if (PlayerRigibody.velocity.x > 0)
            {
                PlayerRigibody.velocity -= Friction ;


            }
            else if (PlayerRigibody.velocity.x < 0)
            {
            PlayerRigibody.velocity += Friction;
        }
      
    }

    //Jump Code
    private void HandleJump()
    {
       if(Input.GetKeyDown(KeyCode.W))
        {
            PlayerRigibody.velocity = Vector2.up * jumpforce;

        }
    }
}

