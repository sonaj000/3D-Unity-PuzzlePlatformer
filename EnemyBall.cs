using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBall : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 location;
    Rigidbody test;
    void Start()
    {
        location = transform.position;
        test = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<BoxCollider>() != null) //check if it has it. 
        {
            Destroy(gameObject);
        }
        else if (collision.collider.GetComponent<CharacterController>() != null)
        {
            SceneManager.LoadScene("test"); //Load scene called Game
        }
    }
}
