using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonpanArmScript : MonoBehaviour
{
    public float targetRotation = 90f;  // 목표 회전 각도
    public float rotationSpeed = 30f;   // 회전 속도

    public bool Rotating;

    public GameObject wonpanPlate;

    private WonpanArmAnimate waa;


    private void Start()
    {
       waa = wonpanPlate.GetComponent<WonpanArmAnimate>();
    }

    void Update()
    {
        // 현재 회전 각도
        float currentRotation = transform.rotation.eulerAngles.y;

        // 목표 각도와 현재 각도 사이의 각도 차이를 계산
        float angleDifference = Mathf.DeltaAngle(currentRotation, targetRotation+45f);

        // 회전 속도와 각도 차이를 이용하여 회전
        float rotationAmount = Mathf.Min(rotationSpeed * Time.deltaTime, Mathf.Abs(angleDifference));

        // 회전 방향 결정
        float rotationDirection = Mathf.Sign(angleDifference);

        // 회전 수행
        if (waa.doorclear)
        transform.Rotate(Vector3.up, rotationDirection * rotationAmount);



        if (Mathf.Abs(angleDifference) < 0.01f)
        {
            Rotating = false;
        }
        else
        {
            Rotating = true;
        }
    }
}