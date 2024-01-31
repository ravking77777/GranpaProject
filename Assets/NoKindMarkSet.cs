using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoKindMarkSet : MonoBehaviour
{

    public GameObject preP;
    public GameObject catP;
    public GameObject nokP;


    // Update is called once per frame
    void Update()
    {
     if ((!preP.gameObject.activeSelf) && (!catP.gameObject.activeSelf))
            nokP.gameObject.SetActive(true);
     else
            nokP.gameObject.SetActive(false);
        

    }
}
