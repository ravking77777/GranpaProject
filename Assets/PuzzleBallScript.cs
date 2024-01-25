using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PuzzleBallScript : MonoBehaviour
{
    private PuzzleCircleBody Cstep;
    public Transform BaseBody;
    private bool Moved=false;
    private bool Lock = false;



    // 충돌이 발생했을 때 호출되는 메서드
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("whatIsCB"))
        {

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