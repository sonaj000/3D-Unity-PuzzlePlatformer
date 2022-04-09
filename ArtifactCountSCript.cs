using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ArtifactCountSCript : MonoBehaviour
{
    public TMP_Text artifactText;
    public float artifactCount;
    //[SerializeField] CountdownEndTimer timerCount;

    // Start is called before the first frame update
    void Start()
    {
        //timerCount = gameObject.GetComponent<CountdownEndTimer>();
        artifactText = GetComponent<TMP_Text>();
        artifactCount = 0;
        artifactText.text = "Collectibles: " + artifactCount.ToString() + "/3";
    }

    // Update is called once per frame
    void Update()
    {
        artifactText.text = "Collectibles: " + artifactCount.ToString() + "/3";
    }
    public void artifactCollected()
    {
        artifactCount += 1;
      //  timerCount.addTime();
    }
}
