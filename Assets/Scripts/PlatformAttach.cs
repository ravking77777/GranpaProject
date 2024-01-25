using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    public PlayerController pm;
    public GameObject Player;
    public Rigidbody prb;



    private void OnCollisionEnter(Collision other)
    {
        if (!pm.swinging)
        if (other.gameObject == Player)
        {
            prb.AddForce(new Vector3(0, -5, 0), ForceMode.Impulse);
            //pm.grounded = true;
            

            //pm.onMovingPlatform = true;
            Player.transform.parent = transform;
         
        }



        }

    private void OnCollisionExit(Collision other)
    {
        
        if (other.gameObject == Player)
        {
            if (Player.transform.parent = transform)
            Player.transform.parent = null;

            //pm.onMovingPlatform = false;
           // pm.grounded = false;
        }
        

    }

}
