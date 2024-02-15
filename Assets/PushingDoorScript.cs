using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushingDoorScript : MonoBehaviour
{
    public bool switchOn;    // 변수 A
    public float distanceB;   // 변수 B (거리)
    public float speed;       // 이동 속도
    private Vector3 initialPosition;  // 초기 위치

    void Start()
    {
        // 초기 위치 설정
        initialPosition = transform.position;
    }

    void Update()
    {
        if (switchOn)
        {
            // 변수 A가 true일 때 초기 위치를 기준으로 x축으로 이동
            MoveObject();
        }
    }

    void MoveObject()
    {
        // 현재 위치를 가져옴
        Vector3 currentPosition = transform.position;

        // x축으로 초기 위치를 기준으로 distanceB만큼 이동
        currentPosition.x = Mathf.MoveTowards(currentPosition.x, initialPosition.x + distanceB, speed * Time.deltaTime);

        // 새로운 위치를 설정
        transform.position = currentPosition;
    }
}