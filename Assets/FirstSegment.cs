using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSegment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // ù ��° �罽 ���׸�Ʈ�� ������ ������ ����
        FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = null; // ������ ����
    }
}
