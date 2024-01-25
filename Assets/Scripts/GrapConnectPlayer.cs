using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapConnectPlayer : MonoBehaviour
{
    public Animator animm;
    public PlayerController ppc;


    // Start is called before the first frame update
    void Start()
    {
        animm=GetComponent<Animator>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (ppc.state == PlayerController.MovementState.walking)
        {

            if (ppc.movingnow!=0)
            {
                animm.SetBool("ButtonWalk", true);
                animm.SetBool("ButtonMove", false);
                animm.SetBool("ButtonFreeze", false);
                animm.SetBool("ButtonStand", false);

                


            }
            else
            {
                animm.SetBool("ButtonWalk", false);
                animm.SetBool("ButtonMove", false);
                animm.SetBool("ButtonFreeze", false);
                animm.SetBool("ButtonStand", true);
            }

            
        }
        else if (ppc.state == PlayerController.MovementState.sprinting)
        {
            animm.SetBool("ButtonMove", true);
            animm.SetBool("ButtonWalk", false);
            animm.SetBool("ButtonFreeze", false);
            animm.SetBool("ButtonStand", false);
        }
        else
        {
            animm.SetTrigger("doFreeze");
            animm.SetBool("ButtonFreeze", true);

        }

    }
}
