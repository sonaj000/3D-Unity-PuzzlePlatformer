using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]

public class CountdownEndTimer : MonoBehaviour
{
    public float Timer = 600f;
    public TMP_Text CountdownTimer;

    void Start()
    {
        CountdownTimer = GetComponent<TMP_Text>();
        timeLeft();
    }

    private void Update()
    {
        Timer -= Time.deltaTime;
        timeLeft();
    }
    private void timeLeft ()
    {
        if (Timer < 0f)
        {
            Timer = 0;
            CountdownTimer.text = "YOU LOSE";
        }
        else
        {
            CountdownTimer.text = "Time left: " + Timer.ToString();
        }
    }
    public void addTime()
    {
        Timer += 60f;
    }

}
