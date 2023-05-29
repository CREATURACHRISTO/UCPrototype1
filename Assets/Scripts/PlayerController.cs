using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public float steerSpeed = 30;

    public float jumpSpeed = 10;
    public float shiftMult = 2;

    float shiftVal = 1;

    float yInput;
    float xInput;

    float jumpInput;

    private Vector3 starterPosition;
    private Rigidbody rb;
    
    // Called at start of program
    private void Start()
    {
        starterPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();

        HandleResetPosition();
    }

    void HandleMovement()
    {
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");

        jumpInput = Input.GetAxis("Jump");

        // shiftVal is 1 if shift isn't being pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftVal = shiftMult;
        }
        else
        {
            shiftVal = 1;
        }

        // Jump translation
        transform.Translate(Vector3.up * jumpSpeed * jumpInput * Time.deltaTime);

        // Forward and back translation
        transform.Translate(Vector3.forward * speed * Time.deltaTime * yInput * shiftVal);

        // Turn rotation, uses yInput because vans don't turn on the spot
        transform.Rotate(Vector3.up, xInput * Time.deltaTime * steerSpeed * yInput * shiftVal);
    }
    
    void ResetPosition(Vector3 newPosition)
    {
        transform.position = newPosition;
        transform.rotation = Quaternion.identity;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void ResetPosition()
    {
        Vector3 newPos = transform.position;
        newPos.y += 5;
        ResetPosition(newPos);
    }

    void HandleResetPosition()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                ResetPosition(starterPosition);
            }
            else
            {
                ResetPosition();
            }
        }
    }
}
