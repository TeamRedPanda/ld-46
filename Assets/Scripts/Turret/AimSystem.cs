using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSystem : MonoBehaviour
{
    public Transform m_Target;
    public Transform m_Pivot;

    public float m_AngularSpeed;

    // Update is called once per frame
    void Update()
    {
        // Determine which direction to rotate towards
        Vector3 targetDirection = m_Target.position - transform.position;
        targetDirection.y = 0f;

        // The step size is equal to speed times frame time.
        float singleStep = m_AngularSpeed * Time.deltaTime;

        // Rotate the forward vector towards the target direction by one step
        Vector3 newDirection = Vector3.RotateTowards(m_Pivot.forward, targetDirection, singleStep, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);

        // Calculate a rotation a step closer to the target and applies rotation to this object
        m_Pivot.rotation = Quaternion.LookRotation(newDirection);
    }
}
