using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainDelete : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    public bool IsOnlyPlayer=false;
    public Rigidbody pb;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            if (IsOnlyPlayer)
            {
                if (player.transform.parent == this.transform)
                {

                    pb.AddForce(player.transform.up * 10f, ForceMode.Impulse);
                }
            }
        }
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            if (IsOnlyPlayer)
            {
                if (player.transform.parent==this.transform)
                {
                    
                    player.transform.parent = null;

                }
            }

            Destroy(this.gameObject);

            
        }

    }
}
