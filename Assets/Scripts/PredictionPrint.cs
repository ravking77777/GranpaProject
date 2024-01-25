using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PredictionPrint : MonoBehaviour
{
    public float constantSize = 5f; // 원하는 상수 크기
    public Camera pCamera;

    void Update()
    {
        // 카메라와의 상대적인 거리에 따라 크기 조절
        Vector3 dir = pCamera.transform.position - transform.position;
        float distance = Vector3.Distance(pCamera.transform.position, transform.position);
        float sizeFactor = distance / constantSize;
        transform.localScale = new Vector3(sizeFactor, sizeFactor, sizeFactor);
        transform.rotation = Quaternion.LookRotation(dir);
    }
}
