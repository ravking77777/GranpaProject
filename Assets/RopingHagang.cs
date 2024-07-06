using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopingHagang : MonoBehaviour
{
    
    public RopeAttach RAScript; // RopeAttach ��ũ��Ʈ�� ����

    // y�� �Ʒ��� �̵��ϴ� �ִ�ġ
    public float maxYPosition = 0f;
    public float downSpeed = 1f;

    void Update()
    {
        // Ư�� ������ ������ true�� ���
        if (RAScript.isRope) // 'isTrue'�� ���� ������� ���������� ��ü�ؾ� �մϴ�.
        {
            // y�� �Ʒ��� �̵�
            if (transform.position.y > maxYPosition)
            {
                transform.position += downSpeed * Vector3.down * Time.deltaTime;
            }
        }
    }
}