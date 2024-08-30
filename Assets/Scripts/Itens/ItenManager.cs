using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Singelton;

public class ItenManager : Singelton<ItenManager>
{
    public int coins;
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
