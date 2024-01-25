using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuCam;
    public GameObject gameCam;
    public GameObject gamePlayer;

    public GameObject menuPanel;
    public GameObject IngamePanel;
    public GameObject optionPanel;
    public GameObject backButton;

    public AudioClip bgmClip2;


    public static bool GameIsPaused = false;

    KeyCode escapeKey = KeyCode.Escape;

    



    public CanvasGroup canvasGroup;
    public float fadeInDuration = 1.5f;

    void Start()
    {
       
        canvasGroup.alpha = 0f; // 초기에 투명하게 설정
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeInDuration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = Mathf.Clamp01(elapsedTime / fadeInDuration); // 시간에 따라 알파 값을 증가시킴
            yield return null;
        }
    }



public void GameStart()
    {

        menuCam.SetActive(false);
        gameCam.SetActive(true);
        gamePlayer.SetActive(true);
        menuPanel.SetActive(false);
        IngamePanel.SetActive(true);
        backButton.SetActive(false);

        AudioManager.instance.bgmClip = bgmClip2;
        AudioManager.instance.BGMAwake();
        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
        
    }

    public void OptionStart()
    {
        menuPanel.SetActive(false);
        optionPanel.SetActive(true);
        IngamePanel.SetActive(false);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
    }

    public void OptionEnd()
    {
        menuPanel.SetActive(true);
        optionPanel.SetActive(false);
        IngamePanel.SetActive(false);

        AudioManager.instance.PlaySfx(AudioManager.Sfx.Button);
    }

    public void Resume()
    {
        optionPanel.SetActive(false);
        IngamePanel.SetActive(true);
        GameIsPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Pause()
    {
        optionPanel.SetActive(true);
        IngamePanel.SetActive(false);
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void GameExit()
    {

        Application.Quit();
    }

    private void Update()
    {
        if ((Input.GetKeyDown(escapeKey)) && (gamePlayer.activeSelf==true))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }

    }

 }
