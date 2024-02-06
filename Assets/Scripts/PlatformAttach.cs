using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public PlayerController pm;
    public GameObject Player;

    public GameObject Ele;
    public Rigidbody prb;



    private void OnCollisionEnter(Collision other)
    {
        if (!pm.swinging)
        if (other.gameObject == Player)
        {
            prb.AddForce(new Vector3(0, -5, 0), ForceMode.Impulse);

            Player.transform.parent = transform;
         
        }


        if (other.gameObject == Ele)
        {
            //prb.AddForce(new Vector3(0, -5, 0), ForceMode.Impulse);

            Ele.transform.parent = transform;

        }

    }

    private void OnCollisionExit(Collision other)
    {
        
        if (other.gameObject == Player)
        {
            if (Player.transform.parent = transform)
            Player.transform.parent = null;

        }
        

    }

}
