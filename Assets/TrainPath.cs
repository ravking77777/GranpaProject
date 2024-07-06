using System.Collections.Generic;
using UnityEngine;

public class TrainPath : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 5f;
    private int currentWaypointIndex = 0;
    [HideInInspector]
    public bool isStopped = false;
    public string stopAtWaypointName = "StopWaypoint"; // ó�� ���� ��������Ʈ�� �̸�
    private bool stopFunctionDisabled = false; // ���ߴ� ��� ��Ȱ��ȭ ����

    void Update()
    {
        if (isStopped || waypoints.Count == 0) return;

        Transform targetWaypoint = waypoints[currentWaypointIndex];
        Vector3 direction = targetWaypoint.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (direction.magnitude <= distanceThisFrame)
        {
            // ��������Ʈ�� �������� �� ó��
            if (targetWaypoint.name == stopAtWaypointName && !stopFunctionDisabled)
            {
                isStopped = true;
                stopFunctionDisabled = true; // ���ߴ� ��� ��Ȱ��ȭ
                return; // ���߰� ���� ������ �������� ����
            }

            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0; // ����
            }

            // ���ߴ� ����� ��Ȱ��ȭ�� ���¿��� �ٸ� StopWaypoint�� �������� �� �ٽ� Ȱ��ȭ
            if (targetWaypoint.name == stopAtWaypointName)
            {
                stopFunctionDisabled = false; // ���ߴ� ��� Ȱ��ȭ
            }
        }
        else
        {
            transform.Translate(direction.normalized * distanceThisFrame, Space.World);
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * speed * 0.2f);
        }
    }

    // �ܺο��� ȣ���Ͽ� ������ �ٽ� �����̰� �ϴ� �޼���
    public void Resume()
    {
        isStopped = false;
    }
}