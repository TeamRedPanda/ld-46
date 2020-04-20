using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSurface : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_AudioClip;

    void OnTriggerEnter(Collider other)
    {
        var normal = transform.right;
        var bullet = other.GetComponent<Bullet>();
        if (bullet != null) {
            bullet.Reflect(normal.normalized, DamageSource.NeutralBullet);
            m_AudioSource.PlayOneShot(m_AudioClip);
        }
    }
}
