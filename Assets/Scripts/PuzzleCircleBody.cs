using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCircleBody : MonoBehaviour
{
    Vector3 currentRotation;
    public float CircleRot=0;
    public float CircleStep = 0;
    public bool SwitchOn=false;
    public bool ElectricOn=false;
    private int SystemStart=0;

    public Transform myPlanetSide;

    public GameObject sgsCheckObj_1;
    public GameObject sgsCheckObj_2;

    [HideInInspector]
    public GameObject PCB1;
    [HideInInspector]
    public GameObject PCB2;
    [HideInInspector]
    public GameObject PCB3;
    [HideInInspector]
    public GameObject PCB4;

    [SerializeField]
    private LayerMask targetLayer;
    [SerializeField]
    private LayerMask GrapLayer;

    private void Start()
    {
        currentRotation.x = 0;
        currentRotation.y = 0;
        currentRotation.z = 0;

        PCB1 = GameObject.Find("GalaxyBodyCircle001");
        PCB2 = GameObject.Find("GalaxyBodyCircle002");
        PCB3 = GameObject.Find("GalaxyBodyCircle003");
        PCB4 = GameObject.Find("GalaxyBodyCircle004");
    }


    private void FixedUpdate()
    {

        if (CircleStep > 0)
        {

            currentRotation.y += 2;
            transform.rotation = Quaternion.Euler(currentRotation);
            myPlanetSide.rotation = Quaternion.Euler(currentRotation);
            CircleStep--;
        }

    }



    void Update()
    {
        if (SystemStart==2)
        if (CircleStep <= 0)
        {
            currentRotation.y = CircleRot;
            CircleStep = 0;
            transform.rotation = Quaternion.Euler(currentRotation);
            myPlanetSide.rotation = Quaternion.Euler(currentRotation);
            if (PCB1.activeSelf==false)
                PCB1.SetActive(true);
            if (PCB2.activeSelf == false)
                PCB2.SetActive(true);
            if (PCB3.activeSelf == false)
                PCB3.SetActive(true);
            if (PCB4.activeSelf==false)
                PCB4.SetActive(true);
            SystemStart = 0;


            GameObject[] objectsInLayer = FindObjectsOfType<GameObject>();
            foreach (GameObject obj in objectsInLayer)
            {
                // 오브젝트가 대상 레이어에 속해 있는지 확인
                if (IsInLayer(obj, targetLayer))
                {
                    // 오브젝트의 현재 회전값 가져오기
                    Vector3 currentRotation = obj.transform.rotation.eulerAngles;

                    // y 축 회전을 90도 단위로 조정
                    currentRotation.y = Mathf.Round(currentRotation.y / 90) * 90;

                    // 새로운 회전값 적용
                    obj.transform.rotation = Quaternion.Euler(currentRotation);
                }
            }

            GameObject[] objectsInLayer2 = FindObjectsOfType<GameObject>();
            foreach (GameObject obj2 in objectsInLayer2)
            {
                // 오브젝트가 대상 레이어에 속해 있는지 확인
                if (IsInLayer(obj2, GrapLayer))
                {
                    SphereGrapScript sgs = obj2.GetComponent<SphereGrapScript>();
                    if (sgs!= null)
                    {
                        sgs.switchOn = false;

                    }
                        
                }
            }

        }

        if (SwitchOn)
        if (SystemStart==0)
        {
            sgsCheckObj_1.SetActive(true);
            sgsCheckObj_2.SetActive(true);

            Invoke("CircleRotation", 1.0f);
            SystemStart = 1;
        }
    }

    void CircleRotation()
    {
        PCB1.SetActive(false);
        PCB2.SetActive(false);
        PCB3.SetActive(false);
        PCB4.SetActive(false);

        gameObject.SetActive(true);
        CircleStep = 45;
        CircleRot += 90f;
        SwitchOn = false;
        SystemStart = 2;
    }

    bool IsInLayer(GameObject obj, LayerMask layerMask)
    {
        // 오브젝트가 주어진 레이어에 속하는지 확인
        return (layerMask == (layerMask | (1 << obj.layer)));
    }


}
