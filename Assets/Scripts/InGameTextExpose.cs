using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameTextExpose : MonoBehaviour
{
    public float exposeDelay = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (exposeDelay > 0)
        {
            exposeDelay -= 1f;

        }
        else
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }

        }

    }
}
