using UnityEngine;
using System.Collections.Generic;

public class FreightCar : MonoBehaviour
{
    public Transform train; // ���� ������ Transform
    public float followDelay = 1.0f; // ȭ������ ������ ���󰡴� �ð� ���� (�� ����)
    private Queue<Vector3> positionQueue = new Queue<Vector3>(); // ������ ��ġ�� ������ ť
    private Queue<Quaternion> rotationQueue = new Queue<Quaternion>(); // ������ ȸ���� ������ ť
    private float updateInterval = 0.1f; // ��ġ�� ȸ���� ����� �ð� ����
    public TrainPath tp;

    void Start()
    {
        // �ʱ�ȭ �� ť�� ���ϴ�.
        positionQueue.Clear();
        rotationQueue.Clear();

        // �ʱ�ȭ ������ ������ ��ġ�� ȸ���� ����մϴ�.
        for (float t = 0; t < followDelay; t += updateInterval)
        {
            positionQueue.Enqueue(train.position);
            rotationQueue.Enqueue(train.rotation);
        }
    }

    void FixedUpdate()
    {
        if (tp.isStopped == false)
        {
            // ������ ���� ��ġ�� ȸ���� ť�� �����մϴ�.
            positionQueue.Enqueue(train.position);
            rotationQueue.Enqueue(train.rotation);

            // ������ ��ġ�� ȸ�� ������ ť���� �����ϰ� ȭ������ �����մϴ�.
            if (positionQueue.Count > Mathf.CeilToInt(followDelay / updateInterval))
            {
                transform.position = positionQueue.Dequeue();
                transform.rotation = rotationQueue.Dequeue();
            }

        }

        
    }
}