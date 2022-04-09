using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappear2 : MonoBehaviour
{
    public Renderer rend;
    public Collider collider;
    public float invis_time = 4;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        collider = GetComponent<BoxCollider>();
        collider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > invis_time && rend.enabled == true && collider.enabled == true)
        {
            invis_time += 4;
            rend.enabled = false;
            collider.enabled = false;
        }

        else if (Time.time > invis_time && rend.enabled == false && collider.enabled == false)
        {
            invis_time += 4;
            rend.enabled = true;
            collider.enabled = true;
        }

    }
}
