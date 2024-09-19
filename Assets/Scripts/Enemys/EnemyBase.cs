using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour, IKillable , IDamageable<int>
{

    public EnemyData enemyData;

    private protected int _current_life;


    #region CODE
    private void Awake()
    {
        Init();
    }
  

    protected virtual void Init()
    {

        _current_life = enemyData.StartLife;
    }

    public virtual void Attack() 
    {
        Attack();
        

    }   
    #endregion
    #region INTERFACES
    public void Kill()
    {
        Destroy(gameObject);
        Debug.Log("Morreu" + "Vida:" + _current_life);
    }

    public void Damage(int f)
    {
       
        _current_life -= f;
        transform.localScale *= 0.9f;
        if (_current_life <= 0)
        {
           
            Kill();
        }
       
    }
    public void Damage(GameObject a)
    {
        throw new System.NotImplementedException();
    }





    #endregion
}

