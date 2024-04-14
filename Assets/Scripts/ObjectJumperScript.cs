using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectJumperScript : MonoBehaviour
{
    public float jumpForce = 10f;
    private float jDel = 0f;
    public LayerMask targetLayers;

    public Animator animator;
    public string aniClip;

    void Start()
    {

        if (animator != null)
        {
            // 애니메이션의 속도를 0으로 설정
            animator.speed = 0f;
        }
    }

    private void LateUpdate()
    {
        if (jDel>0)
            jDel-=Time.smoothDeltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        // 충돌한 오브젝트가 targetLayers에 포함된 레이어에 속하는지 확인
        if (jDel<=0)
        if ((targetLayers & (1 << other.gameObject.layer)) != 0)
        {
            // 충돌한 오브젝트가 플레이어인 경우에만 점프 적용
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                    animator.Play(aniClip, 0, 0f); // 여기서 "YourAnimationName"은 재생할 애니메이션의 이름입니다.
                    animator.speed = 1f;
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jDel = 1f;
            }
            
        }
    }
}