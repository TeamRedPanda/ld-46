using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public DamageSource m_BulletType = DamageSource.NeutralBullet;
    int m_Bounces = 3;

    [SerializeField] TrailRenderer m_Trail;

    void Update()
    {
        if (m_BulletType == DamageSource.NeutralBullet)
            m_Trail.startColor = new Color(183, 157, 42);
        else
            m_Trail.startColor = new Color(183, 50, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        ProcessCollisionWithDamageable(other);
        ProcessCollisionWithBounceSurface(other);
    }

    private void ProcessCollisionWithBounceSurface(Collider other)
    {
        var bounceSurface = other.GetComponent<BounceSurface>();

        if (bounceSurface != null) {
            m_Bounces -= (m_BulletType == DamageSource.PlayerBullet) ? 3 : 1;

            if (m_Bounces <= 0)
                Destroy(gameObject);
        }
    }

    private void ProcessCollisionWithDamageable(Collider other)
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

    public void ReflectTowards(Vector3 direction, DamageSource source)
    {
        m_BulletType = source;

        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);
    }
}
