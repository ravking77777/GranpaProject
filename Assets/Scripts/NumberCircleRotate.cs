using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberCircleRotate : MonoBehaviour
{
    private Vector3 previousMousePosition;

    public Camera cam;

    public int RotNum;

    private int rotating;

    private float rot;

    public int soonser;
    public GameObject NumLever;
    public NumberCall numCall;


    void Start()
    {
        numCall = NumLever.GetComponent<NumberCall>();
    }

    void FixedUpdate()
    {
        if (rotating > 0)
        {
            rotating--;

            rot += (36 * RotNum - rot) * 0.1f;

            transform.rotation = Quaternion.Euler(-90 + rot, 0, 180);

        }
        else
        {
            if (RotNum == 10)
                RotNum = 0;
            if (RotNum < 0)
                RotNum = 9;
            numCall.cNum[soonser] = RotNum;
            rot = 36 * RotNum;
            transform.rotation = Quaternion.Euler(-90 + rot, 0, 180);
        }
    
    }


    public void RotateUp()
    {
        
        RotNum++;

        
        rotating = 30;
    }


    public void RotateDown()
    {
        RotNum--;

        rotating = 30;
    }
}