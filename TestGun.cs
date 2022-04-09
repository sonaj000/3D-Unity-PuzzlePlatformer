using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera cam;
    [SerializeField] float GrabDistance = 10.0f, throwForce = 10.0f, Lerpspeed = 10.0f;

    [SerializeField] Transform objectHolder;
    public Char2 example;
    public GameObject Owner;
    public GameObject MPlayer;

    private bool bIsHolding;
    private bool bIsNotHolding;
    GameObject target;
    Rigidbody grabbedRB;
    Collider exception;
    public bool CanRelease;
    public bool bisFrozen;
    public Rigidbody holdRB;
    public Vector3 ogpos;
    private int counter;
    private LineRenderer show;
    private Transform[] points;
    void Start()
    {
        Screen.SetResolution(1280, 720, true);

        Owner = transform.parent.gameObject;
        MPlayer = Owner.transform.parent.gameObject;
        cam = Owner.GetComponent<Camera>();
        exception = example.GetComponent<CharacterController>();
        bIsHolding = false;
        CanRelease = false;
        ogpos = objectHolder.transform.localPosition;
        Debug.Log(ogpos);
        counter = 0;
        show = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbedRB && bIsHolding)
        {
            //Debug.Log(grabbedRB.GetComponent<GameObject>());
            grabbedRB.detectCollisions = true;
            grabbedRB.MovePosition(objectHolder.transform.position);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (counter > 0)
                {
                    objectHolder.transform.position += objectHolder.transform.forward * -1;
                    counter -= 1;
                }
                
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                if (counter < 6)
                {
                    objectHolder.transform.position -= objectHolder.transform.forward * -1;
                    counter += 1;
                }
                
            }
        }
        else if(!bIsHolding)
        {
            Release();
        }
        if (Input.GetMouseButtonDown(0))
        {
            SwapBool();
            Hold();
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            Lock();
        }
      
    }
    private void SwapBool()
    {
        if (bIsHolding)
        {
            bIsHolding = false;
        }
        else if (!bIsHolding)
        {
            bIsHolding = true;
        }
    }
    public void LineSetup(Transform[] points)
    {
        show.positionCount = points.Length;
        this.points = points;
    }
    private void Hold()
    {
        RaycastHit Hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Debug.DrawLine(ray.origin, ray.direction * 40.0f, Color.black, 20.0f, false);
        if (Physics.Raycast(ray, out Hit, GrabDistance)) //(ray, out Hit, GrabDistance))
        {
            target = Hit.transform.gameObject;
            grabbedRB = target.GetComponent<Rigidbody>();
            Debug.Log("it has been hit");
            if (grabbedRB != exception)
            {
                grabbedRB.isKinematic = true;
                Debug.Log("we grab it");
            }
        }
    }
    private void Release()
    {
        if (grabbedRB)
        {
            bIsHolding = false;
            grabbedRB.transform.position = grabbedRB.transform.position;
            grabbedRB.isKinematic = false;
            grabbedRB.useGravity = true;
            CanRelease = false;
            grabbedRB = null;
            objectHolder.transform.localPosition = ogpos;
            counter = 0;
        }

    }
    private void Lock()
    {
        RaycastHit Hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Debug.DrawLine(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 60.0f, Color.black, 20.0f, false);
        if (Physics.Raycast(ray, out Hit, GrabDistance)) //(ray, out Hit, GrabDistance))
        {
            target = Hit.transform.gameObject;
            holdRB = target.GetComponent<Rigidbody>();
            if (holdRB != exception && !bisFrozen)
            {
                holdRB.isKinematic = true;
                bisFrozen = true;
                holdRB.freezeRotation = true;
                holdRB.constraints = RigidbodyConstraints.FreezePosition;
                Debug.Log("frozen");
            }
            else if (holdRB != exception && bisFrozen)
            {
                holdRB.isKinematic = false;
                bisFrozen = false;
                holdRB.freezeRotation = false;
                holdRB.constraints = RigidbodyConstraints.None;
                Debug.Log("not frozen");
            }
        }
    }
}
