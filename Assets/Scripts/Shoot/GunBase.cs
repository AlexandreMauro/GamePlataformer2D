using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform PlayerSideReference;
    public Transform positionToShoot;
    public float timeBetweenShoots = .1f;
    private Coroutine _currentCoroutine;


    private void Awake()
    {
        PlayerSideReference = GameObject.FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
          _currentCoroutine = StartCoroutine(StartShoot());
        }

        else if (Input.GetKeyUp(KeyCode.J))
        {
            if (_currentCoroutine != null)
                StopCoroutine(_currentCoroutine);
        }
    }



    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoots);
        }
    }

    private void Shoot()
    {
        var projectile = Instantiate(prefabProjectile);
        projectile.transform.localPosition = positionToShoot.transform.position;
        projectile.side = PlayerSideReference.transform.localScale.x;
    }

}
