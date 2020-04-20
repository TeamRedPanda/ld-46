using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletMovement m_Movement;

    DamageSource m_BulletType = DamageSource.NeutralBullet;

    void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(m_BulletType);
            Destroy(gameObject);
        }
    }

    public void Reflect(Vector3 normal)
    {
        m_BulletType = DamageSource.PlayerBullet;

        var currentDirection = transform.forward;
        var newDirection = currentDirection - 2 * Vector3.Dot(normal, currentDirection) * normal;

        transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
        m_Movement.Speed *= 1.4f;
    }
}
