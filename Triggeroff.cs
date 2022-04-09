using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggeroff : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        var AllBots = FindObjectsOfType<Bot>();
        Debug.Log("passed through");
        foreach (Bot test in AllBots)
        {
            test.CanFire = false;
        }
    }
}
