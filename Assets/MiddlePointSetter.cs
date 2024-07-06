using UnityEngine;

public class MiddlePointSetter : MonoBehaviour
{
    // 두 오브젝트를 public으로 가져옵니다.
    public Transform object1;
    public Transform object2;

    void Update()
    {
        // 두 오브젝트가 null이 아닌지 확인합니다.
        if (object1 != null && object2 != null)
        {
            // 두 오브젝트의 중간 좌표를 계산합니다.
            Vector3 middlePoint = (object1.position + object2.position) / 2;

            // 자신의 위치를 중간 좌표로 설정합니다.
            transform.position = middlePoint;
        }
    }
}