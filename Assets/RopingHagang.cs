using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopingHagang : MonoBehaviour
{
    
    public RopeAttach RAScript; // RopeAttach 스크립트를 참조

    // y축 아래로 이동하는 최대치
    public float maxYPosition = 0f;
    public float downSpeed = 1f;

    void Update()
    {
        // 특정 변수의 조건이 true일 경우
        if (RAScript.isRope) // 'isTrue'는 실제 사용중인 변수명으로 대체해야 합니다.
        {
            // y축 아래로 이동
            if (transform.position.y > maxYPosition)
            {
                transform.position += downSpeed * Vector3.down * Time.deltaTime;
            }
        }
    }
}