using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController m_CharacterController;

    public float Acceleration;
    public float Break;

    public float MaxSpeed = 10;

    public float Speed { get; private set; }
    private Quaternion m_Heading;

    void Awake()
    {
        m_CharacterController = GetComponent<CharacterController>();
    }

    void Start()
    {
        m_Heading = transform.rotation;
    }

    void Update()
    {
        // Gravity
        var movement = new Vector3();
        movement.y = -9.81f * Time.deltaTime;

        m_CharacterController.Move(movement);
    }

    public void LookAt(Vector3 direction)
    {
        m_Heading = Quaternion.LookRotation(direction);
        transform.rotation = m_Heading;
    }

    public void StopMovement()
    {
        Speed = 0;
    }

    public void Move(Vector3 direction, bool lookAt)
    {
        if (direction.sqrMagnitude <= 0.1) {
            // We don't have any input, start breaking
            Speed -= Break * Time.deltaTime;
        } else {
            // We are moving, start accelerating
            Speed += direction.magnitude * Acceleration * Time.deltaTime;

            if (lookAt) {
                m_Heading = Quaternion.LookRotation(direction);
                transform.rotation = m_Heading;
            }
        }

        // Can't go beyond max speed or below 0.
        Speed = Mathf.Clamp(Speed, 0f, MaxSpeed);

        // Running
        var movement = direction * Speed * Time.deltaTime;

        m_CharacterController.Move(movement);
    }

    public void LookAt(Quaternion direction)
    {
        m_Heading = direction;
        transform.rotation = direction;
    }
}
