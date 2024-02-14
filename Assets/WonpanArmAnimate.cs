using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonpanArmAnimate : MonoBehaviour
{
    public AnimationClip animationClip;  // Inspector에서 애니메이션 클립을 설정

    public Animator animator;
    private float forwardStartFrame = 0f;
    private float forwardEndFrame = 100f;  // 예시로 0에서 100프레임까지 재생
    private float reverseStartFrame = 100f; // 예시로 100프레임부터 역재생
    private float reverseEndFrame = 0f;     // 역재생 종료 프레임
    private bool isForward = true;  // 정방향인지 역재생인지 여부

    public GameObject WonpanObj;

    WonpanArmScript was;

    void Start()
    {
        was = WonpanObj.GetComponent<WonpanArmScript>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isForward)
            {
                PlayAnimationWithFramesRange(forwardStartFrame, forwardEndFrame);
            }
            else
            {
                ReverseAnimationWithFramesRange(reverseStartFrame, reverseEndFrame);
            }

            // 방향 전환
            isForward = !isForward;
        }
    }

    void PlayAnimationWithFramesRange(float start, float end)
    {
        float startNormalizedTime = start / animationClip.length;
        float endNormalizedTime = end / animationClip.length;

        animator.SetFloat("AnimationSpeed", 1f);
        animator.Play(animationClip.name, 0, startNormalizedTime);
    }

    void ReverseAnimationWithFramesRange(float start, float end)
    {
        float startNormalizedTime = start / animationClip.length;
        float endNormalizedTime = end / animationClip.length;

        animator.SetFloat("AnimationSpeed", -1f);
        animator.Play(animationClip.name, 0, startNormalizedTime);
    }
}