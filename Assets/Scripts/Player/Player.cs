using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D PlayerRigibody;
    public Vector2 Velocity;

    public float Speed;
    private void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            // PlayerRigibody.MovePosition(PlayerRigibody.position + Velocity * Time.deltaTime);
            PlayerRigibody.velocity = new Vector2(Speed, PlayerRigibody.velocity.y);

        }
        else if(Input.GetKey(KeyCode.A))
        {
            PlayerRigibody.velocity = new Vector2(-Speed, PlayerRigibody.velocity.y);
            // PlayerRigibody.MovePosition(PlayerRigibody.position - Velocity * Time.deltaTime);
        }
    }
}
