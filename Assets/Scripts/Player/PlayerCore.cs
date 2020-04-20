using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_HurtSound;
    [SerializeField] CountView m_StrikeCountView;

    [SerializeField] PlayerInput m_Input;

    private int m_StrikeCount = 0;

    public void Damage()
    {
        m_AudioSource.PlayOneShot(m_HurtSound);
        m_StrikeCount++;
        m_StrikeCountView.UpdateCount(m_StrikeCount);

        if (m_StrikeCount >= 3) {
            m_Input.StopInput();
            FindObjectOfType<GameController>().IsGameOver = true;
        }
    }
}
