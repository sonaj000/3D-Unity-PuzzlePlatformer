using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateM : MonoBehaviour
{
    public bool plateTriggered = false;
    [SerializeField] private Renderer rend;
    float weight = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        plateTriggered = true;
        rend.material.color = Color.green;

    }

    private void OnTriggerExit(Collider other)
    {
            plateTriggered = false;
            rend.material.color = Color.red;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
