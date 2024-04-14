using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuzzleBallScript : MonoBehaviour
{
    private PuzzleCircleBody Cstep;
    private ClearSphere CBcheck;
    public Transform BaseBody;
    private bool Moved=false;
    private bool Lock = false;

    [HideInInspector]
    public bool KeyBall = false;
    public bool IsKey = false;

    public GameObject targetMaterialObject;
    [HideInInspector]
    public Material KBmaterial1;
    public Material KBmaterial2;

    private Renderer rend;
    private float kballDel=0;



    private void Start()
    {
       rend = targetMaterialObject.GetComponent<Renderer>();
       KBmaterial1 = rend.material;
    }



    private void FixedUpdate()
    {
        if (KeyBall && IsKey)
        {
            rend.material = KBmaterial2;
        }
        else
        {
            rend.material = KBmaterial1;
        }

        if (kballDel > 0)
        {
            KeyBall = true;
            kballDel -= 1f;
        }
        else
            KeyBall = false;

    }

    // 충돌이 발생했을 때 호출되는 메서드
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("whatIsCB"))
        {
            CBcheck = collision.gameObject.GetComponent<ClearSphere>();
            if (CBcheck != null)
            {
                
                if (CBcheck.clearSphere && IsKey && KeyBall)
                {
                    CBcheck.clearOn = true;

                }
                else
                {
                    CBcheck.clearOn = false;

                }

            }

            if (!Moved)
            if (Lock)
            {
                transform.position = collision.transform.position;
                Lock = false;

            }

        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("whatIsGB"))
        {
            Animator anim = collision.transform.GetComponent<Animator>();
            Cstep = collision.gameObject.GetComponent<PuzzleCircleBody>();

            if (Cstep != null)
            {
                if (Cstep.ElectricOn)
                {
                    kballDel = 2f;
                }
                

                if (Cstep.CircleStep > 0)
                {
                    transform.SetParent(collision.transform, true);
                    Moved = true;
                }
                else
                {
                    
                    if (Moved)
                    {
                        transform.SetParent(BaseBody);
                        Moved = false;
                        Lock= true;
                    }

                }
            }

            
        }

    }
}