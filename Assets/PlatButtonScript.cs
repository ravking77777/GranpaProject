using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatButtonScript : MonoBehaviour
{

    public Material Testm1;
    public Material Testm2;

    private float mdel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (mdel > 0)
        {
            Renderer rend = gameObject.GetComponent<Renderer>();
            rend.material = Testm2;

            mdel--;

        }
        else
        {
            Renderer rend = gameObject.GetComponent<Renderer>();
            rend.material = Testm1;
        }

    }



    private void OnTriggerStay(Collider collision)
    {
        int targetLayer = LayerMask.NameToLayer("whatIsCatchable");

        if (collision.gameObject.layer == targetLayer)
        {
            
            mdel = 3f;

        }
    }
}
