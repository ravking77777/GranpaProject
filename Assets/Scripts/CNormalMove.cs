using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CNormalMove : MonoBehaviour
{
    public float speed = 20f; // 이동 속도
    private Rigidbody rb;
    public float deathTime = 300f;

    public GameObject prediction;
    public GameObject Player;
    public Swinging pSwing;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true; // isKinematic을 true로 설정

        pSwing= Player.GetComponent<Swinging>();
    }

    void FixedUpdate()
    {
        // 특정 방향으로 이동
        MoveForward();

        if (deathTime > 0)
            deathTime--;
        else
        {
            if (prediction.transform.parent == this.transform)
            {

                prediction.transform.parent = null;
                pSwing.StopSwinging();

            }

            Destroy(this.gameObject);
        }

    }

    void MoveForward()
    {
        // Rigidbody를 직접 이용하여 특정 방향으로 이동
        Vector3 moveDirection = transform.parent.forward;
        rb.MovePosition(rb.position + moveDirection * speed * Time.deltaTime);
    }
}