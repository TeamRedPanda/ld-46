using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    DamageSource m_BulletType = DamageSource.NeutralBullet;

    void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(m_BulletType);
            Destroy(gameObject);
        }
    }

    public void Reflect(Vector3 normal, DamageSource source)
    {
        m_BulletType = source;

        var currentDirection = transform.forward;
        var newDirection = currentDirection - 2 * Vector3.Dot(normal, currentDirection) * normal;

        transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
    }
}
