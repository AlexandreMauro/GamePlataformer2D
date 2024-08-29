using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItenManager : MonoBehaviour
{
    public int coins;


    public static ItenManager instance;

    private void Awake()
    {
        if(instance ==null)
        {
            instance = this;

        }else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
    }



    public void addCoins( int amaunt = 1)
    {
        coins += amaunt;
    }
}
