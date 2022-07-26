using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseAnimation : MonoBehaviour
{
    public Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void WinAnimation()
    {
        animator.SetBool("IsJumping", true);
        int random = Random.Range(0, 2);
        animator.SetInteger("DanceInt", random);
        animator.SetBool("IsDancing", true);
    }
    public void LoseAnimation()
    {
        animator.SetBool("IsDefeat", true);
        animator.SetBool("IsClapping", true);
    }
}
