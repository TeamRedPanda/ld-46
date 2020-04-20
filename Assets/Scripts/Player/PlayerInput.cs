using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerAttack))]
public class PlayerInput : MonoBehaviour
{
    PlayerMovement m_PlayerMovement;
    PlayerAttack m_PLayerAttack;
    Transform m_CameraPosition;
    Camera m_MainCamera;

    bool m_Enabled = true;

    void Awake()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();
        m_PLayerAttack = GetComponent<PlayerAttack>();
        m_MainCamera = FindObjectOfType<Camera>();
        m_CameraPosition = m_MainCamera.transform;
    }

    internal void StopInput()
    {
        m_Enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Enabled == false)
            return;

        ProcessMovementInput();
        ProcessLookDirection();

        if (Input.GetMouseButtonDown(0)) {
            m_PLayerAttack.Attack();
        }
    }

    private void ProcessLookDirection()
    {
        var positionInScreen = m_MainCamera.WorldToScreenPoint(transform.position);
        var mousePosition = Input.mousePosition;
        var direction = mousePosition - positionInScreen;
        direction.z = direction.y;
        direction.y = 0f;
        m_PlayerMovement.LookAt(Quaternion.LookRotation(direction, Vector3.up));
    }

    private void ProcessMovementInput()
    {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");

        var direction = new Vector3(horizontal, 0f, vertical);
        var cameraRotation = Quaternion.Euler(0, m_CameraPosition.rotation.eulerAngles.y, 0);
        direction = cameraRotation * direction;
        m_PlayerMovement.Move(direction.normalized, false);
    }
}
