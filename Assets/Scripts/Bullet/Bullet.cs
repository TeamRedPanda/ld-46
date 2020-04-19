using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] BulletMovement m_Movement;
    void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();

        if (damageable != null) {
            damageable.Damage(DamageSource.NeutralBullet);
            Destroy(gameObject);
        }
    }

    public void Reflect(Vector3 normal)
    {
        var currentDirection = transform.forward;
        var newDirection = 2 * Vector3.Dot(normal, -currentDirection) * normal - currentDirection;

        transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
        m_Movement.Speed *= 1.4f;
    }
}
