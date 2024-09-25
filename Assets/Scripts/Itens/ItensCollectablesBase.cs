using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItensCollectablesBase : MonoBehaviour
{
    public string PlayerTag = "Player";
    public ParticleSystem ParticleSystem;

    private void Awake()
    {
        if (ParticleSystem != null) ParticleSystem.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(PlayerTag))
        {

            Collected();
        }
    }

   
    protected virtual void  Collected()
    {
        
        gameObject.SetActive(false);
        OnCollected();
    }

    protected virtual void OnCollected()
    {
        if (ParticleSystem != null) ParticleSystem.Play() ;
    }

   
}
