using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NumberCircleButton : MonoBehaviour
{
    public Transform player; // 첫 번째 오브젝트의 Transform
    public KeyCode conKey;
    public float conCool = 0;
    public Camera cam;

    public Material mClick;
    public Material mOn;

    [HideInInspector]
    public Material mDefault;

    public GameObject BodyObject;

    private Renderer rend;

    public NumberCircleRotate NCR;



    public enum RotateState
    {
        Up,
        Down

    }

    [SerializeField]
    private RotateState selectedRot;


    private void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        mDefault = rend.material;

        NCR = BodyObject.GetComponent<NumberCircleRotate>();

        
    }


    void Update()
    {

        float distance = Vector3.Distance(player.position, transform.position);

        if (conCool > 0)
        {
            conCool -= Time.deltaTime;

            rend.material = mClick;
        }
        else if (rend.material = mClick)
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
                        conCool = 0.9f;

                        if (selectedRot==RotateState.Up)
                            NCR.RotateUp();
                        if (selectedRot == RotateState.Down)
                            NCR.RotateDown();


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
