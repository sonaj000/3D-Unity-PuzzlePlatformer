using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public bool bIsTouching;
    [SerializeField] private Renderer rend;
    public Vector3 startpos;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        startpos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Rigidbody.constraints == RigidbodyConstraints.FreezePosition)
        {
            rend.material.color = Color.red;
        }
        if (m_Rigidbody.constraints == RigidbodyConstraints.None)
        {
            rend.material.color = Color.white;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Box>())
        {
            bIsTouching = true;
            Debug.Log("collision happened");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.GetComponent<Box>())
        {
            Debug.Log("collision stopped");
        }
    }

}
