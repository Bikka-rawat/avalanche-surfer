using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousemove : MonoBehaviour
{
    [SerializeField] Vector3 turn;
    [SerializeField] float sensitivity;

    [SerializeField] float cameraTiltSpeed;
    [SerializeField] float cameraTiltAmount;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        turn.x += Input.GetAxis("Mouse X") * sensitivity;

        turn.y += Input.GetAxis("Mouse Y") * sensitivity;
        

        turn.x = Mathf.Clamp(turn.x, -45, 45);
        turn.y = Mathf.Clamp(turn.y, -30, 10);
        tilt();
        transform.localRotation = Quaternion.Euler(-turn.y, turn.x, turn.z);



    }


    void tilt()
    {
        if (Input.GetKey(KeyCode.D))
        {
            turn.z = Mathf.Lerp(turn.z,-cameraTiltAmount, cameraTiltSpeed);

        }

        else if (Input.GetKey(KeyCode.A))
        {
            turn.z = Mathf.Lerp(turn.z, cameraTiltAmount, cameraTiltSpeed);

        }

        else
        {
            turn.z = Mathf.Lerp(turn.z, 0, cameraTiltSpeed);
        }
    }
}
