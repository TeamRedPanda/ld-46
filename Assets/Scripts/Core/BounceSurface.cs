using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSurface : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var normal = transform.right;
        var bullet = other.GetComponent<Bullet>();
        bullet?.Reflect(normal.normalized, DamageSource.NeutralBullet);
    }
}
