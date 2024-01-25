using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CatchableRopeScript : MonoBehaviour
{
    private Animator animator;
    public string newLayerName = "whatIsGrappleable";
    private Rigidbody rb;

    public bool throwed=false;
    public bool attached=false;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        animator.speed = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collObject = collision.gameObject;

        if (collObject.layer != LayerMask.NameToLayer("whatIsPlayer"))
        {
            if (throwed && !attached)
            {
                if (collision.contacts.Length > 0)
                {

                    ContactPoint contact = collision.contacts[0];
                    Vector3 hitNormal = contact.normal;

                    // 충돌 표면의 법선 벡터로 회전값 계산
                    Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, hitNormal);

                    // 현재 오브젝트를 회전값에 따라 회전
                    transform.rotation = rotation;

                    rb.isKinematic = true;

                    animator.speed = 1.0f;
                    attached = true;

                    transform.SetParent(collision.transform);


                }
            }
        }
    }

    void FixedUpdate()
    {
        // 애니메이션이 끝나면 애니메이션 속도를 0으로 설정
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
        {
            GoToEndFrame();

            if (throwed==false)
                GoToStartFrame();  
        }
    }


    void GoToEndFrame()
    {
        // 애니메이션의 끝 프레임으로 이동
        float animationLength = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, 0.9f);
        animator.speed = 0f;
    }

    void GoToStartFrame()
    {
        // 애니메이션의 끝 프레임으로 이동
        float animationLength = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
        animator.Play(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, 0f);
        animator.speed = 0f;
    }

}