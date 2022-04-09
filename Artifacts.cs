using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Artifacts : MonoBehaviour
{
    [SerializeField]ArtifactCountSCript count;
    // `12 5.94 31.4
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        count.artifactCollected();
        Destroy(transform.gameObject);
    }

}
