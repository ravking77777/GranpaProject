using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleSegment : MonoBehaviour
{
    void ConnectSegments(GameObject segment1, GameObject segment2)
    {
        SpringJoint joint = segment1.AddComponent<SpringJoint>();
        joint.connectedBody = segment2.GetComponent<Rigidbody>();
        joint.spring = 100.0f; // ������ ����
        joint.damper = 5.0f; // ����
        joint.minDistance = 0.1f; // �ּ� �Ÿ�
        joint.maxDistance = 0.5f; // �ִ� �Ÿ�
    }
}
