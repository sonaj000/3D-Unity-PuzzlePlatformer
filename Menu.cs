using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene("test");
    }
    public void StartInt()
    {
        SceneManager.LoadScene("Practice");
    }
    public void End()
    {
        Application.Quit();
    }
    private void Update()
    {
        Cursor.visible = true;
    }
}


