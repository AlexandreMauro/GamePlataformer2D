using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D PlayerRigibody;

    public Animator animator;
    public string BoolWalk = "Walk";


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
           
            PlayerRigibody.velocity = new Vector2(_currentSpeed, PlayerRigibody.velocity.y);
            animator.SetBool(BoolWalk, true);
            PlayerRigibody.transform.localScale = new Vector3(1,1,1);

        }

        else if (Input.GetKey(KeyCode.A))
        {
            PlayerRigibody.velocity = new Vector2(-_currentSpeed, PlayerRigibody.velocity.y);
            animator.SetBool(BoolWalk, true);
            PlayerRigibody.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool(BoolWalk, false);
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
            DOTween.Kill(PlayerRigibody.transform);
           // HandleJumpAnimation();

            if (PlayerRigibody.transform.localScale.x > 0)
            {
               
                PlayerRigibody.transform.localScale = new Vector3(1, 1, 1); ;


            }
            else if (PlayerRigibody.transform.localScale.x < 0)
            {
                PlayerRigibody.transform.localScale = new Vector3(-1, 1, 1); ;
            }


          

           

        }
    }

    private void HandleJumpAnimation()
    {
        
            PlayerRigibody.transform.DOScaleY( PlayerRigibody.transform.localScale.y * JumpScaleY, AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
            PlayerRigibody.transform.DOScaleX(PlayerRigibody.transform.localScale.x *JumpScaleX, AnimationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        
       

    }

}

