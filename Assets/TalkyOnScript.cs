using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkyOnScript : MonoBehaviour
{
    private bool isEscapePressed = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isEscapePressed = true;
            Invoke("DisableObject", 0.2f); // 1초 후에 DisableObject 함수를 호출합니다.
        }


    }

    void DisableObject()
    {
        if (isEscapePressed)
        {
            gameObject.SetActive(false); // 1초 후에 해당 오브젝트를 비활성화합니다.
        }
    }
}
