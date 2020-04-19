using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(DamageSource.NeutralBullet);
            Destroy(gameObject);
        }
    }
}
