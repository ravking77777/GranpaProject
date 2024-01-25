using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LvMovePlat : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        animator.speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.parent == transform)
        {

            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
            {
                float lastFrameTime = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length; // 애니메이션 클립의 길이를 가져옴
                animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, lastFrameTime);
                // 애니메이션이 마지막 프레임에 도달하면 스피드를 0으로 설정
                animator.speed = 0;
            }
            else
                animator.speed = 1f;
        }
        else
        {
            animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, 0); // 현재 애니메이션 클립을 0프레임으로 재생
            animator.speed = 0;
        }
    }
}
