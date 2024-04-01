using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHide : MonoBehaviour
{
    // Panel의 CanvasGroup 컴포넌트
    private CanvasGroup canvasGroup;
    public GameObject TalkyObject;

    private void Start()
    {
        // Panel의 CanvasGroup 컴포넌트를 가져옴
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
        {
            Debug.LogError("CanvasGroup not found");
        }
    }

    private void Update()
    {
        // Tab 키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // 현재 Panel의 상태에 따라 Hide 또는 Show 함수를 호출
            if (canvasGroup.alpha == 1f)
            {
                Hide();
            }
            else
            {

                if ((GameManager.GameIsPaused == false) && (!TalkyObject.activeSelf))
                    Show();
            }
        }
    }

    // Panel을 숨기는 함수
    public void Hide()
    {
        // Panel의 투명도를 0으로 설정하여 화면에서 보이지 않도록 함
        canvasGroup.alpha = 0f;
        // Panel의 상호작용을 비활성화하여 사용자 입력을 막음
        canvasGroup.interactable = false;
        // Panel의 블록을 비활성화하여 다른 UI 요소에 의해 가려지지 않도록 함
        canvasGroup.blocksRaycasts = false;

        GameManager.GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Panel을 보이게 하는 함수 (필요한 경우)
    public void Show()
    {
        // Panel의 투명도를 1로 설정하여 화면에 보이도록 함
        canvasGroup.alpha = 1f;
        // Panel의 상호작용을 활성화하여 사용자 입력을 받도록 함
        canvasGroup.interactable = true;
        // Panel의 블록을 활성화하여 다른 UI 요소에 의해 가려지지 않도록 함
        canvasGroup.blocksRaycasts = true;

        GameManager.GameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}