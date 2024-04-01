using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkyOnScript : MonoBehaviour
{
    private bool isEscapePressed = false;
    public Animator animm;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isEscapePressed = true;
            animm.SetBool("TalkyDown", false);
            Invoke("DisableObject", 0.5f); // 1초 후에 DisableObject 함수를 호출합니다.
        }


    }

    void DisableObject()
    {
        if (isEscapePressed)
        {
            gameObject.SetActive(false); 
        }
    }
}
