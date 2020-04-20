using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_HurtSound;

    public void Damage()
    {
        m_AudioSource.PlayOneShot(m_HurtSound);
    }
}
