using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator m_Animator;
    [SerializeField] Collider m_HitCollider;
    [SerializeField] AudioClip m_SwingAudio;
    [SerializeField] AudioClip m_HitAudio;
    [SerializeField] AudioSource m_AudioSource;

    private bool m_CanSwing = true;

    public void Attack()
    {
        if (m_CanSwing == true) {
            m_AudioSource.PlayOneShot(m_SwingAudio);
            m_Animator.SetTrigger("Swing");
            m_CanSwing = false;
        }
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
        m_AudioSource.PlayOneShot(m_HitAudio);
        bullet.ReflectTowards(transform.forward, DamageSource.PlayerBullet);
    }

    public void BackswingFinished()
    {
        m_CanSwing = true;
    }
}
