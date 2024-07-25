using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorSpeedChecker : MonoBehaviour
{
    [Header("SpeedChecker")]
    public Animator animSelf;
    public float animSpeed = 1f;

    public Animator[] animators; // ���� �ִϸ����͸� �迭�� ����

    [Header("EndingReady")]
    // �ټ��� ������Ʈ�� �����ϱ� ���� �迭
    public GameObject[] objectsToToggle;
    // ���� ���� �ð� (�� ����)
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
            batParent.SetActive(true); // ��� �ִϸ������� �ӵ��� 0���� ũ�� ������Ʈ Ȱ��ȭ

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
            batParent.SetActive(false); // �׷��� ������ ������Ʈ ��Ȱ��ȭ
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
        // ������ �ð� ���� ���
        yield return new WaitForSeconds(time);

        // ������Ʈ���� active ���¸� ��ȯ
        foreach (GameObject obj in objectsToToggle)
        {
            if (obj != null)
            {
                obj.SetActive(!obj.activeSelf);
            }
        }
    }
}