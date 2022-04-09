using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimonFloor : MonoBehaviour
{
    private BoxCollider collide;
    // Start is called before the first frame update
    void Start()
    {
        collide = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Char2>() == true)
        {
            SceneManager.LoadScene("test"); //Load scene called Game
        }
    }
}
