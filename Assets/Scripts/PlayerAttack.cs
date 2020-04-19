using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Animator m_Animator;

    public void Attack()
    {
        m_Animator.SetTrigger("Swing");
    }

    public void Hit()
    {
        Debug.Log("Hit!");
    }

    public void BackswingFinished()
    {

    }
}
