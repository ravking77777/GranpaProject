using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokePush : MonoBehaviour
{
    public float jumpForce = 2f;
    public float pushForce = 4f;
    public LayerMask targetLayers;
    public Rigidbody plrb;

    void OnTriggerStay(Collider other)
    {
        // �浹�� ������Ʈ�� targetLayers�� ���Ե� ���̾ ���ϴ��� Ȯ��
        if (((1 << other.gameObject.layer) & targetLayers) != 0)
        {
            if (plrb != null)
            {
                plrb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                plrb.AddForce(transform.forward * pushForce, ForceMode.Impulse);
            }

        }
    }
}