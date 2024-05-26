using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public float speed = 5f;
    private Track currentTrack;

    void Update()
    {
        if (currentTrack != null)
        {
            currentTrack.MoveTrain(this, speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Track track = other.GetComponent<Track>();
        if (track != null)
        {
            currentTrack = track;
        }
    }
}