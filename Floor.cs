using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.GetComponent<Box>())
        {
            Box yes = collision.collider.gameObject.GetComponent<Box>();
            collision.collider.gameObject.transform.position = yes.startpos + new Vector3(0, 30.0f, 0.0f);
            //Debug.LogError("shot back up");
        }
    }

}
