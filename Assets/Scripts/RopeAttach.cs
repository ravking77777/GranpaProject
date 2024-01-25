using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeAttach : MonoBehaviour
{
    public PlayerController pm;
    public Swinging sw;
    public GameObject pla;
    public GameObject predictionPoint;

    [SerializeField]
    private float predAttachY=0;


    private void FixedUpdate()
    {
        if (sw.swHitObject!=null)
        if (sw.swHitObject.GetInstanceID()==this.gameObject.GetInstanceID())
        {
            GameObject hobj=sw.swHitObject;
            predictionPoint.transform.position = new Vector3(hobj.transform.position.x, hobj.transform.position.y + predAttachY, hobj.transform.position.z);
            predictionPoint.transform.parent = hobj.transform;
            if (pm.onMovingPlatform == true)
            {
                pm.onMovingPlatform = false;
                pla.transform.parent = null;
            }
        }
       

        if (!pm.swinging)
        if (predictionPoint.transform.parent !=null)
        if (predictionPoint.transform.parent = transform)
        {

            predictionPoint.transform.parent = null;
        }

        
    }
        
    
}
