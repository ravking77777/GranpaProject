using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAt : MonoBehaviour
{
    public Transform target; // 카메라가 바라볼 타겟 오브젝트
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

        // 카메라가 타겟 오브젝트를 바라보게 합니다.
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
