using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemeyScale : EnemyBase
{
    public float Scale = 1.5f;
    public float duration = 1;

    public bool _attacking = false;
    public MeshRenderer meshRenderer;

    private Coroutine _currentCoroutine;
    public override void Attack()
    {
       


            if (!_attacking)
            {
                _attacking = true;
                base.Attack();
            Debug.Log("Ataque Inimigo" + enemyData.Force);
           
                StartCoroutine(DelayCall());
               // ChangeColor();
            }
        if (_currentCoroutine == null)
        {
            Debug.Log("Vida do Inimigo:" + _current_life);
            _currentCoroutine = StartCoroutine(ChangeColorCorroutine());
        }
       
    }


    private void ChangeColor()
    {
        for (float i = 0; i >= 0; i -= .001f)
        {
            meshRenderer.material.SetColor(("_Color"), Color.Lerp(Color.white, Color.red, 1 - i));
        }
    }
    public void ResetScale()
    {
        transform.localScale = Vector3.one;
      
        _attacking = false;
    }

    IEnumerator DelayCall()
    {
        yield return new WaitForSeconds(duration);
        transform.localScale = Vector3.one;
        _attacking = false;
    }

    
    IEnumerator ChangeColorCorroutine()
    {
        for (float i = 1f; i >= 0; i -= .005f)
        {
            meshRenderer.material.SetColor(("_Color"), Color.Lerp(Color.white, Color.red, 1 - i));
            yield return new WaitForEndOfFrame();

        }
        _currentCoroutine = null;

        for (float i = 1f; i >= 0; i -= .01f)
        {
            meshRenderer.material.SetColor(("_Color"), Color.Lerp(Color.red, Color.white, 1 - i));
            yield return new WaitForEndOfFrame();

        }

    }
}

