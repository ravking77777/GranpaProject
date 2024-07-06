using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSegment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 첫 번째 사슬 세그먼트를 고정된 지점에 연결
        FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = null; // 고정된 지점
    }
}
