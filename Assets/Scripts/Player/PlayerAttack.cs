using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator m_Animator;
    [SerializeField] Collider m_HitCollider;

    public void Attack()
    {
        m_Animator.SetTrigger("Swing");
    }

    public void Hit()
    {
        Debug.Log("Hit!");
        var center = m_HitCollider.bounds.center;
        var extents = m_HitCollider.bounds.extents;
        var orientation = m_HitCollider.transform.rotation;
        Collider[] objectsHit = Physics.OverlapBox(center, extents, orientation);

        foreach (var objectHit in objectsHit) {
            var bullet = objectHit.GetComponent<Bullet>();
            if (bullet != null)
                ReflectBullet(bullet);
        }
    }

    private void ReflectBullet(Bullet bullet)
    {
        var normal = bullet.transform.position - transform.position;
        normal.y = 0f;

        bullet.Reflect(normal, DamageSource.PlayerBullet);
    }

    public void BackswingFinished()
    {

    }
}
