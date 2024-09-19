using UnityEngine;

public interface IDamageable<T>
{
    void Damage(T f);
    void Damage(GameObject a);
}

public interface IKillable
{
    void Kill();
}

public interface IDamageableBoss<T>
{
    void DamageB(T i);
}

public interface IKillableBoss
{
    void KillB();
}