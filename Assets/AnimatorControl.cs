using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    public Animator[] animators; // 여러 애니메이터를 참조하는 배열
    public bool animatorOn;
    public float animatorSpeed=1f;

    void Start()
    {
        SetAnimatorsSpeed(0f); // 시작할 때 애니메이터들의 속도를 0으로 설정
    }

    private void Update()
    {
        if (animatorOn)
            SetAnimatorsSpeed(animatorSpeed);
    }

    void SetAnimatorsSpeed(float speed)
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                animator.speed = speed;
            }
        }
    }

}