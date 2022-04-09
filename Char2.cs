using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Char2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float rotationSpeed;
    public float jumpSpeed;
    private float ySpeed;
    private float ogstep;

    public CharacterController charcontrol;
    void Start()
    {
        charcontrol = GetComponent<CharacterController>();
        ogstep = charcontrol.stepOffset;
    }

    private void OnTriggerEnter(Collider plate)
    {
        switch (plate.gameObject.tag)
        {
            case "trampoline":
                ySpeed += 45f;
                break;
        }

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = (transform.right * horizontalInput) / 1 + (transform.forward * verticalInput) / 1;
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y *2 * Time.deltaTime;
        if (charcontrol.isGrounded)
        {
            charcontrol.stepOffset = ogstep;
            ySpeed = -0.5f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ySpeed = jumpSpeed + .5f;
            }
        }
        else
        {
            charcontrol.stepOffset = 0;
        }


        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        charcontrol.Move(velocity * Time.deltaTime);

        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("menu"); //Load scene called Game
        }
    }
}
