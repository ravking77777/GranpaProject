using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Swinging : MonoBehaviour
{
    [Header("Input")]
    public KeyCode swingKey = KeyCode.Mouse0;
    public KeyCode shootKey = KeyCode.Mouse1;

    [Header("References")]
    public LineRenderer lr;
    public Transform gunTip, cam, player;
    public LayerMask whatIsGrappleable;
    public LayerMask whatIsCatchable;
    public PlayerController pm;
    public LayerMask whatIsDisconnect;

    [Header("Swinging")]
    private float maxSwingDistance = 13f; //base 25f
    private Vector3 swingPoint;
    private SpringJoint joint;
    [HideInInspector] public GameObject swHitObject;
    public float drToPointMax=10;

    [Header("OdmGear")]
    public Transform orientation;
    public Rigidbody rb;
    public float horizontalThrustForce;
    public float forwardThrustForce;
    public float extendCableSpeed;

    [Header("Prediction")]
    public RaycastHit predictionHit;
    public float predictionSphereCastRadius;
    public Transform predictionPoint;
    public Transform catchPoint;

    [Header("Catching")]
    public RaycastHit catchHit;
    [HideInInspector] public Rigidbody crb;
    [HideInInspector] public Collider ccol;
    private Vector3 beCatchPoint;
    private bool catchCheck = false;
    private bool catching = false;
    [HideInInspector] public GameObject catchHitObject;
    public GameObject catchTipPunch;
    public GameObject catchTipPp;
    public GameObject cEmptyObject;
    public Material catchMaterial;
    private Renderer catchRend;
    private Material saveMaterial;
    public float shootForce;
    public Animator shtAnim;
    public Animator airAnim;
    private bool aired;


    [Header("Other")]
    private float swingDelay = 0f;
    public float swingStartSpeed=12;
    public GameObject gunTrigger;
    public GameObject gunTipPunch;
    public GameObject gunTipPp;
    public GameObject gunTipFront;
    [HideInInspector] public GameObject hitObject;
    public ParticleSystem ps;
    public ParticleSystem ps_shoot;
    private CatchableRopeScript crs;
    private float catchCool;
    public RuntimeAnimatorController RACstand;
    public RuntimeAnimatorController RACshoot;
    
    

    public Animator gunAnim;

    private bool swingOnce=false;


    private void Awake()
    {
        lr.positionCount = 0;

        

    }

    private void Update()
    {
        if (swingDelay > 0)
            swingDelay -= Time.deltaTime;

        

        if (GameManager.GameIsPaused == false)
        {
           if (Input.GetKeyDown(swingKey))
                {

                if (!catching)
                    if (!predictionPoint.gameObject.activeSelf && catchPoint.gameObject.activeSelf)
                {
                    if (catchCheck == false)
                        if (catchCool <=0f)
                        {
                            StartCatching();
                            
                        }
                        
                }

                if (swingDelay <= 0)
                       StartSwinging();
                    

                }
           if (Input.GetKeyDown(shootKey))
            {
                if (!pm.swinging)
                if (catchPoint.gameObject.activeSelf)
                {

                    if (catchCheck == false)
                        if (catchCool <= 0f)
                        {
                            StartCatching();

                        }

                }
            }


        }

        if (pm.swinging)
        {
            gunAnim.speed = 2f;
            Vector3 directionToPoint = swingPoint - transform.position;
            float distanceFromPoint = Vector3.Distance(transform.position, swingPoint);

            if (distanceFromPoint < drToPointMax)
            {
            float extendedDistanceFromPoint = Vector3.Distance(transform.position, swingPoint) + extendCableSpeed*2;

            joint.maxDistance = extendedDistanceFromPoint * 0.4f; // base 0.8f
            joint.minDistance = extendedDistanceFromPoint * 0.2f; // base 0.25f
            }
        }
        else
        gunAnim.speed = 0f;

        
            if (Input.GetKeyUp(swingKey))
        {
            if (pm.swinging)
                shtAnim.runtimeAnimatorController = RACstand;
            
                StopSwinging();
        }

        if (!pm.swinging)
            if (catching)
        if (Input.GetKeyUp(shootKey))
        {
            shtAnim.runtimeAnimatorController = RACshoot;

            ShootCatching();
        }


        CheckForSwingPoints();
        CheckForCatchPoints();




        if (joint != null)
            if (GameManager.GameIsPaused == false)
            {
                if (!catching)
                OdmGearMovement();
                
            }
    }

    private void FixedUpdate()
    {
        AnimatorClipInfo[] clipInfo = airAnim.GetCurrentAnimatorClipInfo(0);
        AnimatorStateInfo stateInfo = airAnim.GetCurrentAnimatorStateInfo(0);

        if (airAnim.speed > 0f)
        {
            if (stateInfo.normalizedTime >= 0.1f)
            {
                airAnim.speed = 1f;

            }

            if (stateInfo.normalizedTime >= 1f)
            {
                airAnim.Play(clipInfo[0].clip.name, 0, 0f);
                airAnim.speed = 0f;

            }
        }


        if (joint != null)
        if (GameManager.GameIsPaused == false)
        if (catching)
        {
                    catchCool = 0.5f;
                    cEmptyObject.transform.position += (gunTipFront.transform.position - cEmptyObject.transform.position) * 0.2f;
        }

        if (catchCool > 0f)
            catchCool -= Time.smoothDeltaTime;



    }


    void LateUpdate()
    {


        DrawRope();

        if (joint != null)
        {
            if (predictionPoint.transform.parent != null)
            {

                swingPoint = predictionPoint.transform.position;
                joint.connectedAnchor = swingPoint;

                float currentDistance = Vector3.Distance(player.position, predictionPoint.position);

                if (currentDistance > joint.maxDistance)
                    joint.spring = 20f;
                else
                    joint.spring = 4.5f;
            }

            if (catching)
            {
                beCatchPoint = cEmptyObject.transform.position;
                joint.connectedAnchor = player.transform.position;
            }
        }




    }


    private void StartSwinging()
    {

        if (predictionHit.point == Vector3.zero) return;
        if (predictionPoint.gameObject.activeSelf==false) return;

        if (hitObject.transform.parent != null)
        {
            Rigidbody hrb = hitObject.transform.parent.GetComponent<Rigidbody>();
            if (hrb != null)
            {
                if (hrb.velocity.magnitude > 0.01f)
                    return;
            }
        }

        if (GetComponent<Grappling>() != null)
            GetComponent<Grappling>().StopGrapple();

        

        pm.ResetRestrictions();
        pm.grounded = false;
        pm.swinging = true;
        

        player.SetParent(null);
        

        swHitObject = hitObject;

        if (pm.moveSpeed<swingStartSpeed)
        pm.moveSpeed = swingStartSpeed;
        

        swingPoint = predictionHit.point;
        joint = player.gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = swingPoint;

        float distanceFromPoint = Vector3.Distance(player.position, swingPoint);

        joint.maxDistance = distanceFromPoint * 0.4f;
        joint.minDistance = distanceFromPoint * 0.2f;

        joint.spring = 4.5f;
        joint.damper = 10f;
        joint.massScale = 4.5f;

        lr.positionCount = 2;
        currentGrapplePosition = gunTip.position;

    }


    private void StartCatching()
    {
        crs = catchHitObject.GetComponent<CatchableRopeScript>();

        if ((crs != null) && (crs.attached == false) && (crs.throwed == true))
                return;

        if (catchHit.point == Vector3.zero) return;

        if (crs != null)
        {
            crs.throwed = false;

            if (catchHitObject.transform.parent != null)
            {
                catchHitObject.transform.SetParent(null);
            }
        }

        catching = true;
        gunTipPp.SetActive(false);

        shtAnim.runtimeAnimatorController = RACshoot;

        crb=catchHitObject.GetComponent<Rigidbody>();
        crb.isKinematic= true;
        

        ccol = catchHitObject.GetComponent<Collider>();
        ccol.enabled = false;

        catchRend = catchHitObject.GetComponent<Renderer>();

        if (catchRend != null)
        {
            saveMaterial = catchRend.material;
            catchRend.material = catchMaterial;

        }

        Vector3 spawnPosition = catchPoint.transform.position;
        cEmptyObject.transform.position = spawnPosition;
        cEmptyObject.transform.rotation = Quaternion.LookRotation(cam.transform.forward);



        catchHitObject.transform.SetParent(cEmptyObject.transform);

        beCatchPoint = catchHit.point;
        joint = cEmptyObject.gameObject.AddComponent<SpringJoint>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedAnchor = beCatchPoint;

        float distanceFromPoint = Vector3.Distance(player.position, beCatchPoint);

        joint.maxDistance = distanceFromPoint * 0.4f;
        joint.minDistance = distanceFromPoint * 0.02f;

        joint.spring = 1f;
        joint.damper = 3f;
        joint.massScale = 1f;

        lr.positionCount = 2;
        currentGrapplePosition = gunTip.position;

    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {

        if (!joint) return;

        if (catching)
        {
            gunTrigger.SetActive(false);
            catchTipPunch.SetActive(true);
            catchTipPp.SetActive(false);
            
        }
        else
        {
            gunTrigger.SetActive(false);
            gunTipPunch.SetActive(true);
            gunTipPp.SetActive(false);
        }

        if (!swingOnce)
        {
            ps.Play();
            gunTipPunch.transform.rotation = Quaternion.LookRotation(cam.transform.forward);

            swingOnce = true;
        }

        if (pm.swinging)
        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, swingPoint, Time.deltaTime * 8f);
        if (catching)
        {
            currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, beCatchPoint, Time.deltaTime * 8f);
            cEmptyObject.transform.rotation = Quaternion.LookRotation(cam.transform.forward);
        }

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public void ShootCatching()
    {
        if (catching)
        {
            
            Rigidbody shootrb = crb;

            gunTrigger.SetActive(true);
            catchTipPunch.SetActive(false);
            catchTipPp.SetActive(true);
            ccol.enabled = true;
            catchHitObject.transform.SetParent(null);
            catchRend.material = saveMaterial;
            shtAnim.runtimeAnimatorController = RACshoot;

            airAnim.speed = 2f;
            ps_shoot.Play();
            gunTipPp.SetActive(true);

            crs = catchHitObject.GetComponent<CatchableRopeScript>();
            if (crs != null)
            {
                crs.throwed = true;
                crs.attached = false;
            }


            catching = false;
            catchCool = 0.5f;

            lr.positionCount = 0;
            Destroy(joint);
            shootrb.isKinematic = false;

            // 카메라의 전방 벡터 가져오기
            Vector3 cameraForward = cam.transform.forward;

            // 힘을 가할 방향 계산
            Vector3 forceDirection = new Vector3(cameraForward.x, cameraForward.y, cameraForward.z).normalized;

            shootrb.AddForce(forceDirection * shootForce);

        }
        
    }

    public void StopSwinging()
    {
        if (pm.swinging == true)
            swingDelay = 0.2f;



        pm.swinging = false;

        swingOnce = false;

        

        if (catching)
        {
            crb.isKinematic = false;
            gunTrigger.SetActive(true);
            catchTipPunch.SetActive(false);
            catchTipPp.SetActive(true);
            ccol.enabled = true;
            catchHitObject.transform.SetParent(null);
            catchRend.material = saveMaterial;



        }
        else
        {

            gunTrigger.SetActive(true);
            gunTipPunch.SetActive(false);
            

            
        }
        
        catching = false;
        gunTipPp.SetActive(true);
        lr.positionCount = 0;
        Destroy(joint);
    }

    private void CheckForSwingPoints()
    {
        if (joint != null) return;

        RaycastHit sphereCastHit;
        Physics.SphereCast(cam.position, predictionSphereCastRadius, cam.forward, out sphereCastHit, maxSwingDistance, whatIsGrappleable);

        RaycastHit raycastHit;
        Physics.Raycast(cam.position, cam.forward, out raycastHit, maxSwingDistance, whatIsGrappleable);

        Vector3 realHitPoint;

        bool hitOk=true;

        

        //direct hit
        if (raycastHit.point != Vector3.zero)
        {

            realHitPoint = raycastHit.point;
            hitObject = raycastHit.collider.gameObject;

            Vector3 direction = cam.position - hitObject.transform.position;
            float distance = direction.magnitude;

            RaycastHit raycastHit2;
            if (Physics.Raycast(cam.position, cam.forward, out raycastHit2, distance, whatIsDisconnect))
            hitOk = false;
        }

        //indirect hit
        else if (sphereCastHit.point != Vector3.zero)
        {
            
            realHitPoint = sphereCastHit.point;
            hitObject = sphereCastHit.collider.gameObject;

            Vector3 direction = cam.position - hitObject.transform.position;
            float distance = direction.magnitude;

            RaycastHit raycastHit2;
            if (Physics.Raycast(cam.position, cam.forward, out raycastHit2, distance, whatIsDisconnect))
            hitOk = false;

        }

        //miss
        else
            realHitPoint = Vector3.zero;

        

        //히트포인트 발견
        if (realHitPoint != Vector3.zero && hitOk==true)
        {
            predictionPoint.gameObject.SetActive(true);
            predictionPoint.position = realHitPoint;

        }
        //히트포인트 발견못하면
        else
        {
            predictionPoint.gameObject.SetActive(false);
        }

        predictionHit = raycastHit.point == Vector3.zero ? sphereCastHit : raycastHit;
    }


    private void CheckForCatchPoints()
    {
        if (joint != null) return;

        RaycastHit sphereCastHit;
        Physics.SphereCast(cam.position, predictionSphereCastRadius, cam.forward, out sphereCastHit, maxSwingDistance, whatIsCatchable);

        RaycastHit raycastHit;
        Physics.Raycast(cam.position, cam.forward, out raycastHit, maxSwingDistance, whatIsCatchable);

        Vector3 realHitPoint;

        bool hitOk = true;

        //direct hit
        if (raycastHit.point != Vector3.zero)
        {
            realHitPoint = raycastHit.point;
            
            if (!catching)
            catchHitObject = raycastHit.collider.gameObject;

            Vector3 direction = cam.position - catchHitObject.transform.position;
            float distance = direction.magnitude;

            RaycastHit raycastHit2;
            if (Physics.Raycast(cam.position, cam.forward, out raycastHit2, distance, whatIsDisconnect))
                hitOk = false;

        }

        //indirect hit
        else if (sphereCastHit.point != Vector3.zero)
        {
            realHitPoint = sphereCastHit.point;
            if (!catching)
                catchHitObject = sphereCastHit.collider.gameObject;


            Vector3 direction = cam.position - catchHitObject.transform.position;
            float distance = direction.magnitude;

            RaycastHit raycastHit2;
            if (Physics.Raycast(cam.position, cam.forward, out raycastHit2, distance, whatIsDisconnect))
                hitOk = false;
        }

        //miss
        else
            realHitPoint = Vector3.zero;

        //히트포인트 발견
        if ((realHitPoint != Vector3.zero) && (hitOk == true))
        {
            catchPoint.gameObject.SetActive(true);
            catchPoint.position = realHitPoint;

        }
        //히트포인트 발견못하면
        else
        {
            catchPoint.gameObject.SetActive(false);
        }

        catchHit = raycastHit.point == Vector3.zero ? sphereCastHit : raycastHit;
    }

    private void OdmGearMovement()
    {
        //right
        if (Input.GetKey(KeyCode.D)) rb.AddForce(orientation.right * horizontalThrustForce * Time.deltaTime);

        //left
        if (Input.GetKey(KeyCode.A)) rb.AddForce(-orientation.right * horizontalThrustForce * Time.deltaTime);

        //forward
        if (Input.GetKey(KeyCode.W)) rb.AddForce(orientation.forward * forwardThrustForce * Time.deltaTime);

        // 줄 줄이기
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 directionToPoint = swingPoint - transform.position;
            float distanceFromPoint = Vector3.Distance(transform.position, swingPoint);

            if (distanceFromPoint > drToPointMax)
            {
                rb.AddForce(directionToPoint.normalized * forwardThrustForce * Time.deltaTime);

                joint.maxDistance = distanceFromPoint * 0.4f; // base 0.8f
                joint.minDistance = distanceFromPoint * 0.2f; // base 0.25f
            }


        }

        // 줄 늘리기
        if (Input.GetKey(KeyCode.S))
        {
            float extendedDistanceFromPoint = Vector3.Distance(transform.position, swingPoint) + extendCableSpeed;

            joint.maxDistance = extendedDistanceFromPoint * 0.4f; // base 0.8f
            joint.minDistance = extendedDistanceFromPoint * 0.2f; // base 0.25f

        }


    }


}