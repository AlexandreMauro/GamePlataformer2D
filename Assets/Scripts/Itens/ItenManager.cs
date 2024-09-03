using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singelton;

public class ItenManager : Singelton<ItenManager>
{
    public int coins;
    public TextMeshProUGUI CoinText;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
    }



    public void addCoins(int amaunt = 1)
    {
        coins += amaunt;
        CoinText.text = "X" + " " + coins.ToString();
    }
}
   
