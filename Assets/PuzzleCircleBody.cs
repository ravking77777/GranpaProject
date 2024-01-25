using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCircleBody : MonoBehaviour
{
    Vector3 currentRotation;
    public float CircleRot=0;
    public float CircleStep = 0;
    public bool SwitchOn=false;

    public GameObject PCB1;
    public GameObject PCB2;
    public GameObject PCB3;
    public GameObject PCB4;

    private void Start()
    {
        currentRotation.x = 0;
        currentRotation.y = 0;
        currentRotation.z = 0;

        PCB1 = GameObject.Find("GalaxyBodyCircle");
        PCB2 = GameObject.Find("GalaxyBodyCircle2");
        PCB3 = GameObject.Find("GalaxyBodyCircle3");
        PCB4 = GameObject.Find("GalaxyBodyCircle4");
    }


    private void FixedUpdate()
    {

        if (CircleStep > 0)
        {
            if (CircleStep > 0)
            {
                currentRotation.y += (CircleRot - currentRotation.y) * 0.1f;
                transform.rotation = Quaternion.Euler(currentRotation);
            }
            CircleStep--;
        }
        

    }


    void Update()
    {

        if (CircleStep <= 0)
        {
            currentRotation.y = CircleRot;
            CircleStep = 0;
            transform.rotation = Quaternion.Euler(currentRotation);

            if (PCB1.activeSelf==false)
            PCB1.SetActive(true);
            if (PCB2.activeSelf == false)
                PCB2.SetActive(true);
            if (PCB3.activeSelf == false)
                PCB3.SetActive(true);
            if (PCB4.activeSelf==false)
            PCB4.SetActive(true);



        }

        if (SwitchOn)
        if (CircleStep==0)
        {
            PCB1.SetActive(false);
                PCB2.SetActive(false);
                PCB3.SetActive(false);
                PCB4.SetActive(false);

                gameObject.SetActive(true);
                CircleStep = 25;
            CircleRot += 90f;
            SwitchOn = false;
        }

    }


}
