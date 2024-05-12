using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatButtonScript : MonoBehaviour
{
    [HideInInspector]
    public Material Testm1;
    public Material Testm2;
    [HideInInspector]
    public Material Elecm1;
    public Material Elecm2;

    private Renderer rend;
    private Renderer rend2;

    private float mdel;

    public PuzzleCircleBody ElectricTarget;

    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        Testm1 = rend.material;
        rend2 = this.GetComponent<Renderer>();
        Elecm1 = rend2.material;
    }

   
    void FixedUpdate()
    {

        if (mdel > 0)
        {
            
            rend.material = Testm2;
            rend2.material = Elecm2;

            ElectricTarget.ElectricOn = true;
            mdel--;

        }
        else
        {
            
            rend.material = Testm1;
            rend2.material = Elecm1;


            ElectricTarget.ElectricOn = false;
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
