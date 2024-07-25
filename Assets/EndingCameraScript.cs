using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target; // ī�޶� �ٶ� Ÿ�� ������Ʈ
    public AnimatorControl animController;
    public GameObject LoadingCanvas;

    [HideInInspector]
    public FadeManager fadeManager;

    private void Start()
    {
        animController.animatorOn = true;

        if (fadeManager == null)
        {
            fadeManager = GameObject.FindObjectOfType<FadeManager>();
        }


        Invoke("SceneFadeOut", 5f);
    }

    void Update()
    {

        // ī�޶� Ÿ�� ������Ʈ�� �ٶ󺸰� �մϴ�.
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

    private void SceneFadeOut()
    {
        fadeManager.StartFadeOut();
        Invoke("GoToNextScene", 2f);
    }

    private void GoToNextScene()
    {
        if (LoadingCanvas != null)
            LoadingCanvas.SetActive(true);
    }
}
