using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Char : MonoBehaviour
{
    private CharacterController controls;
    private Vector3 playerVelocity;
    private float gravityConstant = -9.81f;
    public float playerSpeed = 30.0f;
    public float turn = 0.5f;
    public float turnspeed;
    public float slowdown = 4;
    public bool bIsGrounded;
    private float jumpHeight = 3.0f;
    public LayerMask groundlayer;


    void Start()
    {
        controls = GetComponent<CharacterController>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider plate)
    {
        switch (plate.gameObject.tag)
        {
            case "trampoline":
                playerVelocity.y = 25f;
                break;
        }

    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = (transform.right * horizontal)/slowdown + (transform.forward * vertical)/slowdown;
        controls.Move(direction * playerSpeed * Time.deltaTime);

        playerVelocity.y += gravityConstant * Time.deltaTime;
        controls.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("test"); //Load scene called Game
        }

        bIsGrounded = controls.isGrounded;

        if (bIsGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        if (Input.GetKeyDown(KeyCode.Space) && bIsGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityConstant);
        }
    }

}
