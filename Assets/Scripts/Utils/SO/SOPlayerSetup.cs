using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject
{
   

    /* public float JumpScaleY = 1.3f;
     public float JumpScaleX = .7f;
     public float AnimationDuration=0.3f;
    */
   
    public Ease ease = Ease.OutBack;
    [Header("Triggers")]
    public string BoolWalk = "Walk";
    public string TriggerDeath = "Death";
    public string IntJump = "Jump";

    [Header("Speed Config")]
    public Vector2 Friction = new Vector2(.1f, 0);
    public float jumpforce;
    public float Speed;
    public float RunSpeed;
   

}
