using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float Speed;

    Bullet m_Bullet;

    void Start()
    {
        m_Bullet = GetComponent<Bullet>();
    }

    // Update is called once per frame
    void Update()
    {
        var multiplier = m_Bullet.m_BulletType == DamageSource.NeutralBullet ? 1 : 2;
        transform.position += transform.forward * Speed * Time.deltaTime * multiplier;
    }
}
