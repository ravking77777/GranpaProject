using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLineScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject LoadingCanvas;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject==Player)
        {
            if (LoadingCanvas!=null)
            LoadingCanvas.SetActive(true);

        }


    }
}
