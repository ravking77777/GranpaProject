using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TrainCall : MonoBehaviour
{

    public Material nm1; // 변경할 새로운 머티리얼을 할당할 변수
    public Material nm2;
    public Transform object1; // 첫 번째 오브젝트의 Transform
    public Transform object2; // 두 번째 오브젝트의 Transform
    public KeyCode conKey;
    public float conCool = 0;
    public CreateTrain cret;
    public Camera cam;
    public GameObject interText;
    // Start is called before the first frame update

    

    void Update()
    {
        
        float distance = Vector3.Distance(object1.position, object2.position);

        if (conCool > 0)
        {
            conCool-=Time.deltaTime;
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
            // 마우스가 오브젝트 위에 있을 때 수행할 작업
            if ((hit.collider.gameObject == this.gameObject) && (conCool <= 0) && (distance < 5f))
            {
                interText.SetActive(true);

                if (Input.GetKey(conKey))
                    {
                        Renderer rend = GetComponent<Renderer>(); // 해당 오브젝트의 Renderer 컴포넌트 가져오기
                        rend.material = nm2; // 머티리얼 변경
                        cret.BTrain_Call = true;
                        conCool = 3f;

                        AudioManager.instance.PlaySfx3D(AudioManager.Sfx.Switch, this.gameObject);
                }

            }
            else
                interText.SetActive(false);
        }


    }

   

}
