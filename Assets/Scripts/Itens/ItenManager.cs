using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Core.Singelton;

public class ItenManager : Singelton<ItenManager>
{
    public SOInt coins;
    public TextMeshProUGUI CoinText;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
    }



    public void addCoins(int amaunt = 1)
    {
        coins.value += amaunt;
        CoinText.text = "X" + " " + coins.value.ToString();
    }
}
   
