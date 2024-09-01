using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;
    public float TimeToAutoDesttroy = 2f;
    public float side = 1f;
    public int amauntDamage = 2;
    private void Awake()
    {
        Destroy(gameObject, TimeToAutoDesttroy);
    }
    private void Update()
    {
        transform.Translate(direction* Time.deltaTime * side);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var Enemy = collision.gameObject.GetComponent<EnemyBase>();

        if(Enemy != null)
        {
            Enemy.Damage(amauntDamage);
            Destroy(gameObject);
        }
    }
}
