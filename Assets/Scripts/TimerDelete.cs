using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDelete : MonoBehaviour
{
    public Animator animt;
    private float delcount=10f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (delcount > 0)
            delcount -= Time.smoothDeltaTime;
        else
        { 

            Destroy(this.gameObject);
        }

    }
}
