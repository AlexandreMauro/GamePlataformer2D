using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D PlayerRigibody;

    [Header("Animation Setup")]
    public float JumpScaleY = 1.3f;
    public float JumpScaleX = .7f;
    public float AnimationDuration=0.3f;
    public Ease ease = Ease.OutBack;
    
    [Header("Speed Config")]
    public  Vector2 Friction = new Vector2(.1f,0);
    public float jumpforce;
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
            PlayerRigibody.transform.localScale = Vector2.one;
            DOTween.Kill(PlayerRigibody.transform);
            HandleJumpAnimation();
        }
    }

    private void HandleJumpAnimation()
    {
        
            PlayerRigibody.transform.DOScaleY(JumpScaleY, AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            PlayerRigibody.transform.DOScaleX(JumpScaleX, AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        
       

    }

}

