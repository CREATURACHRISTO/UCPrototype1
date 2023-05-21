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
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yInput = Input.GetAxis("Vertical");
        xInput = Input.GetAxis("Horizontal");

        jumpInput = Input.GetAxis("Jump");
        
        if (Input.GetKey(KeyCode.LeftShift))
        {
            shiftVal = shiftMult;
        } else
        {
            shiftVal = 1;
        }

        transform.Translate(Vector3.up * jumpSpeed * jumpInput * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime * yInput * shiftVal);
        transform.Rotate(Vector3.up, xInput * Time.deltaTime * steerSpeed * yInput * shiftVal);
    }

    
}
