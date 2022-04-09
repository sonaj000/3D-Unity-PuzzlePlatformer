using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LaserFab;
    public Vector3 location;
    public Vector3 rotation;
    public float rotatespeed;
    public float spawntime = 0.0f;
    public float SpawnInterval = 10;
    public GameObject spherepoint;
    public bool CanFire;
    public bool bCanspin;

    void Start()
    {
        Vector3 right = new Vector3(0, 5.0f, 0);
        //var laserchild = Instantiate(LaserFab, this.transform.position, transform.rotation * Quaternion.AngleAxis(90, Vector3.right));
        //laserchild.transform.parent = gameObject.transform;
        location = transform.position;
        CanFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bCanspin)
        {
            transform.Rotate(0, Time.deltaTime * rotatespeed, 0);
        }

        if (Time.time > spawntime && CanFire)
        {
            spawntime += 1.0f;
            shoot();
            Debug.Log("shoot");
        }
    }

    void shoot()
    {
        Vector3 InFront = transform.forward * 5 + transform.position;
        GameObject test = Instantiate(spherepoint, InFront, Quaternion.identity);
        Rigidbody t = test.GetComponent<Rigidbody>();
        t.velocity = transform.forward * 50.0f;
    }
}
