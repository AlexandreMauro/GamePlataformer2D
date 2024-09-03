using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator AttackAnimation;
    public string AttackTrigger = "Attack";
    public string KillTrigger = "Kill";
    public Health healthBase;

    private void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;
        KillState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.transform.name);
        
        var health = collision.gameObject.GetComponent<Health>();
        
        var Player = collision.gameObject.GetComponent<Player>();
        
        if(Player != null)
        {
            AttackState();
            health.Damage(damage);
        }
    }

  

    private void AttackState()
    {
        AttackAnimation.SetTrigger(AttackTrigger);
    }

    private void KillState()
    {
        AttackAnimation.SetTrigger(KillTrigger);
    }

    public void Damage(int amaunt)
    {
        healthBase.Damage(amaunt);
    }

}
