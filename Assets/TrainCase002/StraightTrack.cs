
using UnityEngine;

public class StraightTrack : Track
{
    public override void MoveTrain(Train train, float speed)
    {
        train.transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}