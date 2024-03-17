using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonpanArmAnimate : MonoBehaviour
{
    public Animator animator;
    public AnimationClip animClip;

    public GameObject WonpanObj;
    WonpanArmScript was;

    public bool doormode=false;
    public bool doorclear = false;
    void Start()
    {
        was = WonpanObj.GetComponent<WonpanArmScript>();
        // Animator 컴포넌트 가져오기
        animator = GetComponent<Animator>();

    }


    void Update()
    {

        
        // 애니메이션의 전체 길이
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;

        


        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0f)
        {
            if (doormode)
            {
                animator.speed = 1f;
            }
            else
            {
                StopAnimation();
            }
            
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.5f)
        {

            
            if (!doorclear)
            {
                doorclear = true;
                doormode = true;
                StopAnimation();
            }

            if (was.Rotating)
            {
                doormode = false;
            }

            if (!was.Rotating)
            if (doormode == false)
            {
                animator.speed = 1f;
                doorclear = false;
                
            }
        }

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            StopAnimation();
            doormode = false;
            doorclear = false;
            animator.Play(animClip.name, 0, 0f);
                

        }


    }

    void StopAnimation()
    {
        // 애니메이션 멈춤
        animator.speed = 0f;
    }

}