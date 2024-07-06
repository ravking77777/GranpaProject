using UnityEngine;

public class MiddlePointSetter : MonoBehaviour
{
    // �� ������Ʈ�� public���� �����ɴϴ�.
    public Transform object1;
    public Transform object2;

    void Update()
    {
        // �� ������Ʈ�� null�� �ƴ��� Ȯ���մϴ�.
        if (object1 != null && object2 != null)
        {
            // �� ������Ʈ�� �߰� ��ǥ�� ����մϴ�.
            Vector3 middlePoint = (object1.position + object2.position) / 2;

            // �ڽ��� ��ġ�� �߰� ��ǥ�� �����մϴ�.
            transform.position = middlePoint;
        }
    }
}