using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_HurtSound;

    private int m_StrikeCount = 0;

    public void Damage()
    {
        m_AudioSource.PlayOneShot(m_HurtSound);
        m_StrikeCount++;
    }
}
