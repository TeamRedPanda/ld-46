using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageSource
{
    NeutralBullet,
    PlayerBullet
}

public interface IDamageable
{
    void Damage(DamageSource source);
}
