using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleSegment : MonoBehaviour
{
    void ConnectSegments(GameObject segment1, GameObject segment2)
    {
        SpringJoint joint = segment1.AddComponent<SpringJoint>();
        joint.connectedBody = segment2.GetComponent<Rigidbody>();
        joint.spring = 100.0f; // 스프링 강도
        joint.damper = 5.0f; // 감쇠
        joint.minDistance = 0.1f; // 최소 거리
        joint.maxDistance = 0.5f; // 최대 거리
    }
}
