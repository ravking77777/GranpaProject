using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingRope : MonoBehaviour
{
    public PlayerController pm;
    public GameObject predictionPoint;
    private bool onRope;

   
private void OnTriggerEnter(Collider other)
{
        if ((pm.swinging))
        {
            
            predictionPoint.transform.parent = transform;

            onRope = true;
        }



    }

    private void Update()
    {
        if (onRope==true)
            if (!pm.swinging)
            {
                predictionPoint.transform.parent = null;

                onRope = false;
            }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == predictionPoint)
        {
            predictionPoint.transform.parent = null;

            onRope = false;
        }

    }
}