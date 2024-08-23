using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    public List<GameObject> buttons;
    [Header("Animation")]
    public float duration = 0.5f;
    public float delay = 0.2f;
    public Ease ease= Ease.OutBack;

    private void OnEnable()
    {

        HideButtons();
        Showbuttons();

    }


    private void HideButtons()
    {
       foreach(var b in buttons)
        {
            b.transform.localScale =  Vector3.zero;

            b.SetActive(false);


        }
    }


    private void Showbuttons()
    {
    
    for(var i = 0; i< buttons.Count; i++)
        {
            var b = buttons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
            
        }
    
    }
}
