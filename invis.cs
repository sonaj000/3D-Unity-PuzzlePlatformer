using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invis : MonoBehaviour
{
    public Renderer rend;
    public float invis_time = 0;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > invis_time && rend.enabled == true)
        {
            invis_time += 6;
            rend.enabled = false;

        }

        else if (Time.time > invis_time && rend.enabled == false)
        {
            invis_time += 2f;
            rend.enabled = true;
        }

    }
}
