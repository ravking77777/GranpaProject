using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn120Track : Track
{
    public float trackLength;
    public float trackAngle;


    public override void MoveTrain(Train train, float speed)
    {
        float distance = speed * Time.deltaTime;
        float angle = trackAngle * (distance / trackLength); // trackLength는 선로의 길이
        train.transform.Translate(Vector3.forward * distance);
        train.transform.Rotate(Vector3.up, angle);
    }
}