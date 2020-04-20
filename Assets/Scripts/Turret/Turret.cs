using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] FiringController m_FiringController;
    [SerializeField] AimSystem m_AimSystem;
    public void Break()
    {
        m_FiringController.StopFiring();
        m_AimSystem.StopAiming();
    }
}
