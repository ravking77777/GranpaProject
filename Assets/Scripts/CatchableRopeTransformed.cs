using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchableRopeTransformed : MonoBehaviour
{
    public CatchableRopeScript CRscript; //CatchableRopeScript�� �ִ� ������Ʈ ����
    public string newLayerName = "whatIsGrappleable";


    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (CRscript.throwed==true)
        {
            gameObject.layer = LayerMask.NameToLayer("whatIsGrappleable");
            
        }
        else
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
            
        }
    }

}
