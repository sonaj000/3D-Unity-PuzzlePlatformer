using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class simonroomtext1 : MonoBehaviour {
    public GameObject UiObject;
    void Start()
    {
        UiObject.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            UiObject.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        UiObject.SetActive(false);
    }
    void Update()
    {

    }
}
