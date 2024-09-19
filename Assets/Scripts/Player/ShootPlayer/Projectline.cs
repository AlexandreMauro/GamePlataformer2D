using System;
using System.Collections.Generic;
using UnityEngine;

public class Projectline : MonoBehaviour
{

    public Action OnHitTarget;
    public Vector3 ForceDirection;
    public float TimeToReset = 5f;
    public string TagToLook = "Enemy";
    // Update is called once per frame
    void Update()
    {
        transform.Translate(ForceDirection * Time.deltaTime);
        
    }

    public void StartProjectline()
    {
        Invoke(nameof(Finishtousage), TimeToReset);
    }

    public void Finishtousage()
    {
        // Destroy(gameObject, TimeToDestroyer);
        gameObject.SetActive(false);
        OnHitTarget = null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == TagToLook)
        {
            Destroy(collision.gameObject);
            OnHitTarget?.Invoke();
            Finishtousage();
        }
    }
}
