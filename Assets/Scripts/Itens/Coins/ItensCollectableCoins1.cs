using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensCollectableCoins1 : ItensCollectablesBase
{

    protected override void OnCollected()
    {
        base.OnCollected();
        ItenManager.Instance.addCoins2();


    }
}
