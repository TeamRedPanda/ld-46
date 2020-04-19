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

    // Start is called before the first frame update
    void Start()
    {
        m_TimeSinceLastShot = m_FirePeriod;
    }

    // Update is called once per frame
    void Update()
    {
        m_TimeSinceLastShot += Time.deltaTime;
        if (m_TimeSinceLastShot >= m_FirePeriod) {
            Fire();
        }
    }

    private void Fire()
    {
        m_TimeSinceLastShot = 0f;
        Instantiate(m_BulletPrefab, m_SpawnPoint.position, m_SpawnPoint.rotation);
    }
}
