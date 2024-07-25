using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControl : MonoBehaviour
{
    public Animator[] animators; // ���� �ִϸ����͸� �����ϴ� �迭
    public bool animatorOn;
    public float animatorSpeed=1f;

    void Start()
    {
        SetAnimatorsSpeed(0f); // ������ �� �ִϸ����͵��� �ӵ��� 0���� ����
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