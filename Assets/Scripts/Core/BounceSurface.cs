using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSurface : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var currentDirection = other.transform.forward;
        var normal = transform.right;
        var newDirection = currentDirection - 2 * Vector3.Dot(normal, currentDirection) * normal;

        other.transform.rotation = Quaternion.LookRotation(newDirection, Vector3.up);
    }
}
