using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoves : MonoBehaviour
{
    public Vector3 dir;

    public GameObject Projectile;
    public Transform ShootPointer;
    public PoolManager pool;

    public int DeathNmuber = 0;
    public void SpawnItem()
    {
       
        var obj = pool.GetPoorObjects();
        if (obj != null)
        {
            obj.SetActive(true);
            obj.GetComponent<Projectline>().StartProjectline();
            obj.GetComponent<Projectline>().OnHitTarget = CountDeaths; 
                ;
            // obj.transform.SetParent(null);

            obj.transform.position = ShootPointer.transform.position;
        }
       
    }
    private void CountDeaths()
    {
        DeathNmuber++;
        Debug.Log("Death"+ DeathNmuber);
    }
    private void Update()
    {
       

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(dir * Time.deltaTime);

        }else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-dir * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        { SpawnItem(); }

    }

}
