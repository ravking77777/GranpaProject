using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;
    public Camera myCam;

    public float xRotation;
    public float yRotation;

    public WallRunning wr;
    public PlayerController pm;
    public float wRot;

    private bool wCheck=false;
    public float baseFOV=80;
    public float changeFOV = 0;
    public float changeNum = 0;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    public void OnFOVSlideEvent(float value)
    {
        baseFOV = value;
    }

    public void OnXSlideEvent(float value)
    {
        sensX = value*100;
    }

    public void OnYSlideEvent(float value)
    {
        sensY = value*100;
    }

    private void Update()
    {
        myCam.fieldOfView = baseFOV+changeFOV;
        changeFOV += (changeNum - changeFOV) * 0.05f;

        if (pm.wallrunning || pm.climbing)
        {
            if (!wCheck)
                wCheck = true;
            if (wr.wallLeft)
                wRot += (60 - wRot) * 0.1f;
            if (wr.wallRight)
                wRot += (-64 - wRot) * 0.1f;
        }
        else
        {
            if (wCheck)
            {
                yRotation += wRot;
                wRot=0;
                wCheck = false;

            }
        }
    }

    private void LateUpdate()
    {
        //¸¶¿ì½º
        if (GameManager.GameIsPaused == false)
        {
            if (!pm.wallrunning)
            { 
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.smoothDeltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.smoothDeltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            }

        
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        

        transform.rotation = Quaternion.Euler(xRotation, yRotation + wRot, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);

         }

    }
}
