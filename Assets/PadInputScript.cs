using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PadInputScript : MonoBehaviour
{
    public Transform player; // 첫 번째 오브젝트의 Transform
    public KeyCode conKey;
    public float conCool = 0;
    public Camera cam;

    public Material mClick;
    public Material mOn;
    [HideInInspector]
    public Material mDefault;

    public int iNum;

    public PadTextInput PTI;
    public GameObject padObject;

    private Renderer rend;

    


    private void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        mDefault = rend.material;

        PTI = padObject.GetComponent<PadTextInput>();

    }
    

    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        if (conCool > 0)
        {
            conCool -= Time.deltaTime;

            rend.material = mClick;
        }
        else if (rend.material=mClick)
        {
            rend.material = mDefault;
        }
        

        RaycastHit raycastHit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out raycastHit, distance))
        {

            if (conCool <= 0)
            {
                if ((raycastHit.collider.gameObject == this.gameObject) && (distance < 8f))
                {
                    rend.material = mOn;

                    if (Input.GetKey(conKey))
                    {
                        conCool = 0.3f;


                        PTI.Push(iNum);
                       

                    }

                }
                else
                {
                    rend.material = mDefault;

                }
            }

        }
        else if (rend.material != mClick)
        {
            rend.material = mDefault;
        }


    }


}
