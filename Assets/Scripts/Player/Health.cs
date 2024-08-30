using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int Startlife = 10;

    public bool DestroyOnKill = false;
    public float DelayForKill = 0f;
    private int _currentLife;
    private bool _Isdead = false;

   [SerializeField] private FlashColor _flashColor;

    private void Awake()
    {
        Init();
        if(_flashColor == null)
        {
            _flashColor = GetComponent<FlashColor>();
        }
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

       if(_flashColor != null)
        {
            _flashColor.flash();
        }

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
            Destroy(gameObject,DelayForKill);
        }

    }
}
