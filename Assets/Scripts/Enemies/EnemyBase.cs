using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 10;
    public Animator AttackAnimation;
    public string AttackTrigger = "Attack";
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log(collision.transform.name);
        var health = collision.gameObject.GetComponent<Health>();
        if(collision != null)
        {
            AttackState();
            health.Damage(damage);
        }
    }

    private void AttackState()
    {
        AttackAnimation.SetTrigger(AttackTrigger);
    }

}
