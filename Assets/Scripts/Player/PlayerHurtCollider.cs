using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtCollider : MonoBehaviour, IDamageable
{
    [SerializeField] PlayerCore m_Core;

    public void Damage(DamageSource source)
    {
        m_Core.Damage();
    }
}
