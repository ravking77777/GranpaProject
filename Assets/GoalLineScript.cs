using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalLineScript : MonoBehaviour
{

    public GameObject Player;
    public GameObject LoadingCanvas;

    public GameObject fadeObject;
    public FadeManager fadeManager;


    private void Start()
    {
        fadeManager = fadeObject.GetComponent<FadeManager>();
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject==Player)
        {
            Invoke("GoToNextScene", 2f);
            fadeManager.StartFadeOut();
        }
    }


    private void GoToNextScene()
    {
        if (LoadingCanvas != null)
            LoadingCanvas.SetActive(true);
    }


}
