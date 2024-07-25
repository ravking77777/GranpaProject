using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenBatteryInteract : MonoBehaviour
{
    public Swinging sw;
    public Rigidbody rb;
    private bool prior;
    private float prdel;
    private float matdel;
    public Animator animator;
    private List<GameObject> batObjects = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            sw = playerObject.GetComponent<Swinging>();
        }
        else
        {
            Debug.LogError("Player object not found!");
        }

        // Find all GameObjects in the scene
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>();
        // Add objects with name "BatteryCase" to the list
        foreach (GameObject obj in allObjects)
        {
            if (obj.name == "BatteryCase")
            {
                batObjects.Add(obj);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sw.catchHitObject == this.gameObject)
        {
            prior = true;
            rb.useGravity = true;
        }
        else
        {
            prior = false;
        }

        foreach (GameObject batObject in batObjects)
        {
            if (this.transform.parent == batObject.transform)
            {
                matdel = 0.1f;
            }
        }
    }

    private void FixedUpdate()
    {
        if (prdel > 0)
        {

        }
        else
        {
            prior = false;
        }

        if (matdel > 0)
        {
            matdel -= Time.smoothDeltaTime;

            if (!prior)
            {
                if (animator != null)
                {
                    animator.speed = 1f;
                }
            }

        }
        else
        {
            if (!prior)
            {
                if (animator != null)
                {
                    animator.speed = 0;
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (batObjects.Contains(other.gameObject) && !prior)
        {
            this.transform.SetParent(other.gameObject.transform);
            rb.useGravity = false;
            rb.isKinematic = true;
            transform.position = other.gameObject.transform.position;
            transform.rotation = other.gameObject.transform.rotation;
        }
    }
}
