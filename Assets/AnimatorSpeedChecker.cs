using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeedChecker : MonoBehaviour
{
    [Header("SpeedChecker")]
    public Animator animSelf;
    public float animSpeed = 1f;

    public Animator[] animators; // 여러 애니메이터를 배열로 참조

    [Header("EndingReady")]
    // 다수의 오브젝트를 참조하기 위한 배열
    public GameObject[] objectsToToggle;
    // 실행 지연 시간 (초 단위)
    public float delayTime = 4f;

    [Header("Battery")]
    public GameObject batParent;

    void Update()
    {
        bool allAnimatorsSpeedAboveZero = true;

        foreach (Animator animator in animators)
        {
            if (animator.speed <= 0)
            {
                allAnimatorsSpeedAboveZero = false;
                break;
            }
        }

        if (allAnimatorsSpeedAboveZero)
        {
            batParent.SetActive(true); // 모든 애니메이터의 속도가 0보다 크면 오브젝트 활성화

            bool hasChild = HasSpecificChild(batParent.transform, "GreenBattery");
            if (hasChild)
            {
                if (!GameManager.GameIsPaused)
                { 
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    StartCoroutine(ExecuteAfterTime(delayTime));
                    GameManager.GameIsPaused = true;
                }
                animSelf.speed = animSpeed;
                
            }
            else
                animSelf.speed = 0f;
        }
        else
        {
            batParent.SetActive(false); // 그렇지 않으면 오브젝트 비활성화
            animSelf.speed = 0f;
        }
    }


    bool HasSpecificChild(Transform parent, string targetChildName)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.name == targetChildName)
            {
                return true;
            }
        }
        return false;
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        // 지정된 시간 동안 대기
        yield return new WaitForSeconds(time);

        // 오브젝트들의 active 상태를 전환
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }
}