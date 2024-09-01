using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator AttackAnimation;
    public string AttackTrigger = "Attack";
    public Health healthBase;
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

    public void Damage(int amaunt)
    {
        healthBase.Damage(amaunt);
    }

}
