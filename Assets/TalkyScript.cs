using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkyScript : MonoBehaviour
{
    [Header("������")]
    public Item item;
    [Header("�κ��丮")]
    public Inventory inventory;

    public Transform player; // ù ��° ������Ʈ�� Transform
    public KeyCode conKey;
    public float conCool = 0;
    public Camera cam;
    public GameObject interText;
    public GameObject TalkyObject;
    public AudioClip vocClip;

    public Animator animator;

    void Start()
    {
        if (player == null)
            player = GameObject.FindWithTag("Player").transform;

        if (interText == null)
            interText = GameObject.Find("InterText (TMP)");

        if (TalkyObject == null)
            TalkyObject = GameObject.Find("GranpaTalky");

        if (animator == null)
        {
            Transform grandpaDisc = transform.Find("GrandpaDisc001");
            if (grandpaDisc != null)
            {
                animator = grandpaDisc.GetComponent<Animator>();
            }
            else
            {
                Debug.LogError("GrandpaDisc001 not found as a child of this GameObject.");
            }
        }

        if (animator != null)
        {
            // �ִϸ��̼��� �ӵ��� 0���� ����
            animator.speed = 0f;
        }
    }

        void Update()
    {

        float distance = Vector3.Distance(cam.transform.position, transform.position);

        if (conCool > 0)
        {
            conCool -= Time.deltaTime;
        }



        RaycastHit raycastHit;

        int layerMask = ~LayerMask.GetMask("Ignore Raycast");
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out raycastHit, distance, layerMask))
        {
            // ���콺�� ������Ʈ ���� ���� �� ������ �۾�
            if ((raycastHit.collider.gameObject == this.gameObject) && (conCool <= 0) && (distance < 10f))
            {
                interText.SetActive(true);
                InGameTextExpose igt;
                igt = interText.GetComponent<InGameTextExpose>();

                igt.exposeDelay = 2f;

                if (Input.GetKey(conKey))
                {
                    conCool = 2f;
                    inventory.AddItem(item);

                    TalkyObject.SetActive(true);
                    this.gameObject.SetActive(false);


                    AudioManager.instance.vocClip = vocClip;
                    AudioManager.instance.VOCAwake();


                }

            }

        }


    }



}
