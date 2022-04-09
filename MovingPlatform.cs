using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public bool bIsMoving;
    [SerializeField] bool bAtEnd;
    [SerializeField] bool bAtBegin;
    private Rigidbody Body;
    private Vector3 StartLoc;
    private Vector3 EndLoc;
    public int MoveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        bIsMoving = false;
        bAtBegin = true;
        bAtEnd = false;
        Body = GetComponent<Rigidbody>();
        StartLoc = transform.position;
        EndLoc = transform.position + transform.forward * 60;
        MoveSpeed = 10;
    }
    private void FixedUpdate()
    {
        if (bIsMoving)
        {
            if (bAtBegin)
            {
                Body.MovePosition(transform.position + transform.forward * Time.deltaTime * MoveSpeed);
                if (Vector3.Distance(Body.transform.position, EndLoc) <= 1)
                {
                    Debug.Log("it is at the end");
                    bAtBegin = false;
                    bAtEnd = true;
                }
            }
            else if (bAtEnd)
            {
                Body.MovePosition(transform.position + -1 * transform.forward * Time.deltaTime * MoveSpeed);
                if (Vector3.Distance(Body.transform.position, StartLoc) <= 1)
                {
                    Debug.Log("at the beginning");
                    bAtBegin = true;
                    bAtEnd = false;
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider>())
        {
            Rigidbody test = collision.gameObject.GetComponent<Rigidbody>();
            test.isKinematic = true;
            collision.gameObject.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider>())
        {
            Rigidbody test = collision.gameObject.GetComponent<Rigidbody>();
            test.isKinematic = false;
            collision.gameObject.transform.SetParent(null);
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            other.gameObject.transform.position = gameObject.transform.position;
            Debug.Log("on trigger");
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            other.gameObject.transform.position = gameObject.transform.position;
            Debug.Log("ontriggerstay");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            other.gameObject.transform.position = other.gameObject.transform.position;

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<CharacterController>())
        {
            collision.gameObject.transform.position = gameObject.transform.position;
            Debug.Log("oncollisiontriggerstay");
        }
    }
}
