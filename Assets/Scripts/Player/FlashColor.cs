using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderes;
    public Color Flahcolor = Color.red;
    public float duration;
    [SerializeField] private Tween _currentTween;

    private void OnValidate()
    {

        spriteRenderes = new List<SpriteRenderer>();
        foreach(var child in transform.GetComponentsInChildren<SpriteRenderer>())
        {
            spriteRenderes.Add(child);
        }

    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            flash();
        }
    }

    public void flash()
    {
        if(_currentTween == null)
        {

            _currentTween.Kill();
            spriteRenderes.ForEach( i => i.color = Color.white);
        }
        foreach(var s in spriteRenderes)
        {
            s.DOColor(Flahcolor, duration).SetLoops(2, LoopType.Yoyo);
        }
    }
}
