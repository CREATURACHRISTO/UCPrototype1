using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    bool camFlag;

    // Start is called before the first frame update
    void Start()
    {
        camFlag = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            camFlag = !camFlag;
        }

        if (!camFlag)
        {
            MoveBehindPlayer();
        }
        else
        {
            MoveBesidePlayer();
        }
    }

    void MoveBehindPlayer()
    {
        Vector3 newPos = player.transform.position;
        newPos.y += 4.15f;
        newPos.z -= 7.49f;
        transform.eulerAngles = new Vector3(8.51f, 0, 0);
        transform.position = newPos;
    }

    void MoveBesidePlayer()
    {
        Vector3 newPos = player.transform.position;
        newPos.y = transform.position.y;
        newPos.z = player.transform.position.z;
        newPos.x += 10;
        transform.eulerAngles = new Vector3(0, -90, 0);
        transform.position = newPos;
    }
}
