using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
    public Rigidbody2D PlayerRigibody;
    public Health _healthBase;
    public Animator animator;

    [Header("PlkayerSetup")]
    public SOPlayerSetup soPlayerSetup;

    [Header("Animation Setup")]
    public SOFloat soJumpScaleX;
    public SOFloat soJumpScaleY;
    public SOFloat soAnimationDuration;

    

    private float _currentSpeed;
    private void Awake()
    {
      
        
            if (_healthBase != null)
            {
                _healthBase.OnKill += OnPlayerKill;
            }
       
    }

    private void OnPlayerKill()
    {
        _healthBase.OnKill -= OnPlayerKill;
        animator.SetTrigger(soPlayerSetup.TriggerDeath);
    }

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
           _currentSpeed = soPlayerSetup.RunSpeed;
        }
        else
        {
            _currentSpeed =soPlayerSetup.Speed;
        }


        if (Input.GetKey(KeyCode.D))
        {
           
            PlayerRigibody.velocity = new Vector2(_currentSpeed, PlayerRigibody.velocity.y);
            animator.SetBool(soPlayerSetup.BoolWalk, true);
            PlayerRigibody.transform.localScale = new Vector3(1,1,1);

        }

        else if (Input.GetKey(KeyCode.A))
        {
            PlayerRigibody.velocity = new Vector2(-_currentSpeed, PlayerRigibody.velocity.y);
            animator.SetBool(soPlayerSetup.BoolWalk, true);
            PlayerRigibody.transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            animator.SetBool(soPlayerSetup.BoolWalk, false);
        }
           
        
        if (PlayerRigibody.velocity.x > 0)
            {
                PlayerRigibody.velocity -= soPlayerSetup.Friction ;


            }
            else if (PlayerRigibody.velocity.x < 0)
            {
            PlayerRigibody.velocity += soPlayerSetup.Friction;
        }
      
    }

    //Jump Code
    private void HandleJump()
    {
       if(Input.GetKeyDown(KeyCode.W))
        {
            PlayerRigibody.velocity = Vector2.up * soPlayerSetup.jumpforce;
            var result = PlayerRigibody.transform.localScale.x / PlayerRigibody.transform.localScale.x;

            if (PlayerRigibody.transform.localScale.x > 0)
            {

                PlayerRigibody.transform.localScale = new Vector3(result, 1, 1); ;


            }
            else if (PlayerRigibody.transform.localScale.x < 0)
            {
                PlayerRigibody.transform.localScale = new Vector3(-result, 1, 1); ;
            }



            DOTween.Kill(PlayerRigibody.transform);                    
            HandleJumpAnimation();

        }
    }

    private void HandleJumpAnimation()
    {
        

            PlayerRigibody.transform.DOScaleY(PlayerRigibody.transform.localScale.y * soJumpScaleY.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
            PlayerRigibody.transform.DOScaleX(PlayerRigibody.transform.localScale.x * soJumpScaleX.value, soAnimationDuration.value).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
       
      


    }

}

