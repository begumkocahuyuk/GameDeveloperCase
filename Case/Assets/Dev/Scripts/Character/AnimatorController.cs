using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimatorController : MonoBehaviour
{
    private Animator _mAnimator;

    private void Awake()
    {
        _mAnimator = GetComponent<Animator>();
    }

    public void AnimMove()
    {
        _mAnimator.Play("Move");
    }
    public void AnimIdle()
    {
        _mAnimator.Play("Idle");
    }
}
