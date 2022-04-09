using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CrystalCount : MonoBehaviour
{
    public TMP_Text crystalText;
    public float crystalCount;

    // Start is called before the first frame update
    void Start()
    {
        crystalText = GetComponent<TMP_Text>();
        crystalCount = 0;
        crystalText.text = "Crystals: " + crystalCount.ToString() + "/3";
    }

    // Update is called once per frame
    void Update()
    {
        if (crystalCount == 3)
        {
            SceneManager.LoadScene("Win"); //Load scene called Game
        }
        else
        {
            crystalText.text = "Crystals: " + crystalCount.ToString() + "/3";
        }
    }
    public void crystalCollected()
    {
        crystalCount += 1;
    }
}
