using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElebatorButton : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�

    private float upperLimit = 10f; // ���� �̵� ������ �ִ� ����
    private float lowerLimit = 0f; // �Ʒ��� �̵� ������ �ּ� ����

    public float Limiter = 10f;
    [HideInInspector]
    public bool moveUp = false; // ���� �̵� ������ ���θ� ��Ÿ���� �÷���
    Vector3 currentPosition;

    [HideInInspector]
    public Material Testm1;
    public Material Testm2;

    private Renderer rend;

    private float mdel;


    private void Start()
    {
        currentPosition = transform.parent.transform.position;
        lowerLimit = currentPosition.y;
        upperLimit = currentPosition.y+Limiter;

        rend = gameObject.GetComponent<Renderer>();
        Testm1 = rend.material;
    }

    void FixedUpdate()
    {
        // ������ ����
        MoveUpDown();

        if (mdel > 0)
        {

            rend.material = Testm2;
            mdel--;

            moveUp = true;

        }
        else
        {

            rend.material = Testm1;
            
            moveUp = false;
        }

    }

    void MoveUpDown()
    {
        // ���� ��ġ�� ����
        

        // �� �������� �̵��� �� ���
        float moveAmount = moveSpeed * Time.deltaTime;

        // moveUp �÷��׿� ���� �� �Ǵ� �Ʒ��� �̵�
        if (moveUp)
        {
            currentPosition.y = Mathf.Min(currentPosition.y + moveAmount, upperLimit);
        }
        else
        {
            currentPosition.y = Mathf.Max(currentPosition.y - moveAmount, lowerLimit);
        }

        // ���ο� ��ġ�� �̵�
        transform.parent.transform.position = currentPosition;
    }



    private void OnTriggerStay(Collider collision)
    {
        int targetLayer = LayerMask.NameToLayer("whatIsCatchable");

        if (collision.gameObject.layer == targetLayer)
        {

            mdel = 3f;

        }
    }
}

