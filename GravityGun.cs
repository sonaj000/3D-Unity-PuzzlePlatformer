using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera cam;
    [SerializeField] float GrabDistance = 10.0f, throwForce = 10.0f, Lerpspeed = 10.0f;

    [SerializeField] Transform objectHolder;
    public Char example;
    public GameObject Owner;
    public GameObject MPlayer;

    private bool bIsHolding;
    private bool bIsNotHolding;
    GameObject target;
    Rigidbody grabbedRB;
    Collider exception;
    public bool CanRelease;
    void Start()
    {
        Screen.SetResolution(1280, 720, true);

        Owner = transform.parent.gameObject;
        MPlayer = Owner.transform.parent.gameObject;
        cam = Owner.GetComponent<Camera>();
        exception = example.GetComponent<CharacterController>();
        bIsHolding = false;
        CanRelease = false;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
    }
    void Update()
    {
        if (grabbedRB && bIsHolding && target)
        {
            //Debug.Log(grabbedRB.GetComponent<GameObject>());
            //target.transform.position = Vector3.MoveTowards(target.transform.position, objectHolder.transform.position, 0.3f);
            grabbedRB.AddForce((objectHolder.transform.position - target.transform.position)* 10);
            Debug.Log("it is happening");
            //grabbedRB.MovePosition(objectHolder.transform.position);
            //try with clamp on the force. 
        }
        else if (!bIsHolding)
        {
            Release();
        }
        if (Input.GetMouseButtonDown(0))
        {
            SwapBool();
            Hold();

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
    private void Hold()
    {
        RaycastHit Hit;
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
        Debug.DrawLine(cam.transform.position, cam.transform.TransformDirection(Vector3.forward) * 25.0f, Color.black, 20.0f, false);
        if (Physics.Raycast(ray, out Hit, GrabDistance)) //(ray, out Hit, GrabDistance))
        {
            target = Hit.transform.gameObject;
            grabbedRB = target.GetComponent<Rigidbody>();
            if (grabbedRB != exception)
            {
                //grabbedRB.isKinematic = true;
            }
        }
    }
    private void Release()
    {
        Box ho = target.GetComponent<Box>();
        if (grabbedRB && ho.bIsTouching == false)
        {
            bIsHolding = false;
            grabbedRB.transform.position = grabbedRB.transform.position;
            grabbedRB.isKinematic = false;
            grabbedRB.useGravity = true;
            CanRelease = false;
            grabbedRB = null;
        }
    }
}
