using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiringController : MonoBehaviour
{
    public GameObject m_BulletPrefab;
    public Transform m_Target;
    public Transform m_SpawnPoint;

    [SerializeField] float m_FirePeriod;
    float m_TimeSinceLastShot;

    [SerializeField] AimSystem m_Aim;

    [SerializeField] AudioSource m_AudioSource;
    [SerializeField] AudioClip m_FireSound;

    GameController m_GameController;

    bool m_ShouldFire = true;

    // Start is called before the first frame update
    void Start()
    {
        m_TimeSinceLastShot = m_FirePeriod;
        m_GameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        m_TimeSinceLastShot += Time.deltaTime;
        if (m_TimeSinceLastShot >= m_FirePeriod && m_Aim.IsAiming()) {
            Fire();
        }
    }

    public void StopFiring()
    {
        m_ShouldFire = false;
    }

    private void Fire()
    {
        if (m_ShouldFire == false)
            return;

        if (m_GameController.IsGameOver == true)
            return;

        m_TimeSinceLastShot = 0f;
        Instantiate(m_BulletPrefab, m_SpawnPoint.position, m_SpawnPoint.rotation);
        m_AudioSource.PlayOneShot(m_FireSound);
    }
}
