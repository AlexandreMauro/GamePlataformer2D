using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int Startlife = 10;

    public bool DestroyOnKill = false;
    
    private int _currentLife;
    private bool _Isdead = false;

    private void Awake()
    {
        Init();

    }

    public void Init()
    {
        _currentLife = Startlife;
        _Isdead = false;
    }

    public void Damage(int Damage)
    {
        if (_Isdead) return;
        _currentLife -= Damage;

       

        if(_currentLife <= 0)
        {
            kill();
        }
    }

    public void kill()
    {
        _Isdead = true;
        if(DestroyOnKill)
        {
            Destroy(gameObject);
        }

    }
}
