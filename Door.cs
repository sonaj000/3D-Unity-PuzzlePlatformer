using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]PressurePlateM plate;
    bool opened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (plate.plateTriggered == true && opened == false)
        {
            Vector3 down = new Vector3(0, -50, 0);
            transform.position += down;
            opened = true;
        }
        if (plate.plateTriggered == false && opened == true)
        {
            Vector3 up = new Vector3(0, 50, 0);
            transform.position += up;
            opened = false;
        }

    }
}
