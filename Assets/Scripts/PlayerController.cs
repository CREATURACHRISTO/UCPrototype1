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

    // Update is called once per frame
    void Update()
    {
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");

        jumpInput = Input.GetAxis("Jump");
        
        // shiftVal is 1 if shift isn't being pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftVal = shiftMult;
        } else
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

    
}
