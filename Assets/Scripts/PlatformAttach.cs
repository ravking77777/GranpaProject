using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public PlayerController pm;
    public GameObject Player;
    public Rigidbody prb;
    private int targetLayer;


    private void Start()
    {
        targetLayer = LayerMask.NameToLayer("whatIsCatchable");

    }

    private void OnCollisionEnter(Collision other)
    {
        if (!pm.swinging)
            if (Player != null)
            if (other.gameObject == Player)
            {
                prb.AddForce(new Vector3(0, -5, 0), ForceMode.Impulse);

                Player.transform.parent = transform;

            }


        if (other.gameObject.layer == targetLayer)
            {
            
                other.transform.parent = transform;

            }

    }

    private void OnCollisionExit(Collision other)
    {

        if (other.gameObject == Player)
            if (Player != null)
            {
            if (Player.transform.parent = transform)
                Player.transform.parent = null;

            }


        if (other.gameObject.layer == targetLayer)
        {
            if (other.transform.parent = transform)
                other.transform.parent = null;

        }

    }
}
