using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform cameras;
    public Transform player;
    public float currentY;
    public float currentX;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        currentY = 0;
        currentX = 0;
    }
    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * 250.0f * Time.deltaTime;
        float inputY = Input.GetAxis("Mouse Y") * -250.0f * Time.deltaTime;
        
        currentY -= inputY;
        currentX += inputX;
        currentY = Mathf.Clamp(currentY, -90f, 90f);
        
        if (currentY < -90f | currentY > 90f)
        {
            currentY = 0;
        }
       
        player.localRotation = Quaternion.Euler(currentY,currentX,0f).normalized;
        cameras.rotation = Quaternion.Euler(currentY,currentX,0f).normalized;
    }
}
