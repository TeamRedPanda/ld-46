using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] FiringController m_FiringController;
    [SerializeField] AimSystem m_AimSystem;
    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_BreakSound;


    public void Break()
    {
        FindObjectOfType<TurretController>()?.OnTurretDestroyed();

        m_FiringController.StopFiring();
        m_AimSystem.StopAiming();
        m_AudioSource.PlayOneShot(m_BreakSound);
    }
}
