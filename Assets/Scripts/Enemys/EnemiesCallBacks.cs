using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static EnemiesCallBacks;
using UnityEngine.Events;

public class EnemiesCallBacks : MonoBehaviour
{
    #region Variables

    public UnityEvent eventCallback;

    public EnemyBase enemyBase;

   

    public List<GameObject> gameObjkectsList;
    



    [Header("Inputs")]
    public KeyCode KeyCodeElephanth = KeyCode.A;
    public KeyCode KeyCodeSnake = KeyCode.S;
    public KeyCode KeyCodeBug = KeyCode.D;
    #endregion




    private void Attack()
    {
        foreach(var a in gameObjkectsList) 
        {
            if (a != null)
            {
                var Damageable = a.GetComponent<IDamageable<int>>();

                if (Damageable != null)
                {
                    Damageable.Damage(1);
                   
                }
            
            }
            
        }
    }
   

    private void KeyboardCheck()
    {
        if (Input.GetKeyDown(KeyCodeElephanth))
        {
            eventCallback?.Invoke();
            Attack();
           
        }
        else if (Input.GetKeyDown(KeyCodeSnake))
        {
           
            


        }
        else if (Input.GetKeyDown(KeyCodeBug))
        {

            
        }
       
    }

    void Update()
    {
        KeyboardCheck();
      

    }
}

   
