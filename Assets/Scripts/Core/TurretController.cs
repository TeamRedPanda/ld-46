using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] CountView m_DestroyedTurretCountView;
    int m_DestroyedTurretCount = 0;

    [SerializeField] GameObject m_TurretPrefab;
    [SerializeField] float m_SpawmInterval;
    float m_TimeSinceLastSpawn;

    [SerializeField] int m_SpawnAtStart;
    [SerializeField] int m_MaxTurrets;
    int m_CurrentTurrets;

    [SerializeField] Collider m_SpawmArea;
    [SerializeField] GameObject m_Player;

    [SerializeField] AudioClip m_SpawmSound;
    [SerializeField] AudioSource m_AudioSource;

    void Start()
    {
        for (int i = 0; i < m_SpawnAtStart; i++) {
            SpawmRandomTurret();
        }
    }

    void Update()
    {
        m_TimeSinceLastSpawn += Time.deltaTime;
        if (m_TimeSinceLastSpawn >= m_SpawmInterval && m_CurrentTurrets < m_MaxTurrets) {
            SpawmRandomTurret();
        }
    }

    public void OnTurretDestroyed()
    {
        m_CurrentTurrets--;
        m_DestroyedTurretCount++;
        m_DestroyedTurretCountView.UpdateCount(m_DestroyedTurretCount);
    }

    private void SpawmRandomTurret()
    {
        m_CurrentTurrets++;
        var position = RandomPointInBounds(m_SpawmArea.bounds);
        position.y = 0f;
        var turret = Instantiate(m_TurretPrefab, position, Quaternion.identity);
        turret.GetComponent<AimSystem>().m_Target = m_Player.transform;
        turret.GetComponent<FiringController>().m_Target = m_Player.transform;
        m_AudioSource.PlayOneShot(m_SpawmSound);

        m_TimeSinceLastSpawn = 0f;
    }

    public static Vector3 RandomPointInBounds(Bounds bounds)
    {
        return new Vector3(
            UnityEngine.Random.Range(bounds.min.x, bounds.max.x),
            UnityEngine.Random.Range(bounds.min.y, bounds.max.y),
            UnityEngine.Random.Range(bounds.min.z, bounds.max.z)
        );
    }

}
