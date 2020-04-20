using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtBox : MonoBehaviour, IDamageable
{
    [SerializeField] Turret m_Turret;
    public void Damage(DamageSource source)
    {
        if (source == DamageSource.PlayerBullet) {
            m_Turret.Break();
        }
    }
}
