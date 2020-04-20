using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] CountView m_DestroyedTurretCountView;
    int m_DestroyedTurretCount = 0;

    public void OnTurretDestroyed()
    {
        m_DestroyedTurretCount++;
        m_DestroyedTurretCountView.UpdateCount(m_DestroyedTurretCount);
    }
}
