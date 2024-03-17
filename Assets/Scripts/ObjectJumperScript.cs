using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectJumperScript : MonoBehaviour
{
    public float jumpForce = 10f;
    private float jDel = 10f;
    public LayerMask targetLayers;

    private void LateUpdate()
    {
        if (jDel>0)
            jDel-=Time.smoothDeltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        // 충돌한 오브젝트가 targetLayers에 포함된 레이어에 속하는지 확인
        if (jDel<=0)
        if ((targetLayers & (1 << other.gameObject.layer)) != 0)
        {
            // 충돌한 오브젝트가 플레이어인 경우에만 점프 적용
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    jDel = 1f;
            }
            
        }
    }
}