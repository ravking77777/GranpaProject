using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryToPlay : MonoBehaviour
{
    public Animator[] animators; // ���� �ִϸ����͸� �����ϴ� �迭
    public float animSpeed=1f; //�ִϸ��̼� ���ǵ�

    [Header("Battery")]
    public GameObject batParent;


    void SetAnimatorsSpeed(float speed)
    {
        foreach (Animator animator in animators)
        {
            if (animator != null)
            {
                animator.speed = speed;
            }
        }
    }

    private void Update()
    {
        bool hasChild = HasSpecificChild(batParent.transform, "GreenBattery");
        if (hasChild)
        {
            SetAnimatorsSpeed(animSpeed);
        }
        else
        {
            SetAnimatorsSpeed(0f);
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

}