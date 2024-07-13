using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryMover : MonoBehaviour
{
    public Camera targetCamera;  // Assign the camera in the Inspector

    private Renderer objectRenderer;
    [Header("BatteryInteract")]
    public float margin = 0.1f;  // 예외 범위 설정 (0.1은 10% 여유)
    public float upSpeed; // 위로가는 스피드
    private bool isBattery=false;
    private bool isMoved=false;

    [Header("BatteryCase")]
    public GameObject batParent;

    [Header("SpawnObject")]
    public GameObject objectToSpawn;
    public float xPosition;
    public float yPosition;
    public float zPosition;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isBattery)
        {
            transform.position += upSpeed * Vector3.up * Time.deltaTime;

            if (IsOutOfView())
            {
                gameObject.SetActive(false);
                if (!isMoved)
                {
                    SpawnObject();
                    isMoved = true;
                }
            }
        }
        else
        {
            bool hasGreenBatteryChild = HasSpecificChild(batParent.transform, "GreenBattery");
            // 마우스가 오브젝트 위에 있을 때 수행할 작업
            if (hasGreenBatteryChild)
            {
                isBattery = true;
            }
        }
    }

    bool IsOutOfView()
    {
        Vector3 viewportPosition = targetCamera.WorldToViewportPoint(transform.position);

        // 뷰포트 좌표가 (0,0)에서 (1,1) 범위를 벗어나면 카메라 시야에서 벗어난 것으로 간주
        return viewportPosition.x < -margin || viewportPosition.x > 1 + margin || viewportPosition.y < -margin || viewportPosition.y > 1 + margin || viewportPosition.z < 0;
    }

    bool HasSpecificChild(Transform parent, string targetChildName)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name == targetChildName)
            {
                return true;
            }
        }
        return false;
    }

    void SpawnObject()
    {
        if (objectToSpawn != null)
        {
            Vector3 spawnPosition = new Vector3(xPosition, yPosition, zPosition);
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Object to spawn is not assigned.");
        }
    }
}
