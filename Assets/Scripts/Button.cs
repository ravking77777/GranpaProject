using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Button : MonoBehaviour
{

    public Material nm1; // 변경할 새로운 머티리얼을 할당할 변수
    public Material nm2;
    public Transform object1; // 첫 번째 오브젝트의 Transform
    public Transform object2; // 두 번째 오브젝트의 Transform
    public KeyCode conKey;
    public float conCool = 0;

    public Camera cam;
    public GameObject interText;

    public List<Animator> objectAnimators; // 여러 Animator 컴포넌트를 관리하기 위한 리스트
    public string animationTrigger; // 활성화할 애니메이션의 트리거 이름


    void Update()
    {

        float distance = Vector3.Distance(object1.position, object2.position);

        if (conCool > 0)
        {
            conCool -= Time.deltaTime;
        }
        else
        {
            Renderer rend = GetComponent<Renderer>(); // 해당 오브젝트의 Renderer 컴포넌트 가져오기
            if (rend.material = nm2)
            {
                rend.material = nm1;
            }

        }
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if ((hit.collider.gameObject == this.gameObject) && (conCool <= 0) && (distance < 5f))
            {
                interText.SetActive(true);

                if (Input.GetKey(conKey))
                {
                    Renderer rend = GetComponent<Renderer>();
                    rend.material = nm2;

                    // 모든 애니메이터에 대해 애니메이션 트리거 활성화
                    foreach (Animator animator in objectAnimators)
                    {
                        animator.SetTrigger(animationTrigger);
                    }

                    conCool = 3f;
                    AudioManager.instance.PlaySfx3D(AudioManager.Sfx.Switch, this.gameObject);
                }
            }
            else
            {
                interText.SetActive(false);
            }

        }
    }
}

   


