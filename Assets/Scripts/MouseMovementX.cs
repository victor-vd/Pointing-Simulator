using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementX : MonoBehaviour
{
    [SerializeField] private ToggleCam toggleCam;

    [SerializeField] private float mouseSensitivity = MouseMovementY.mouseSensitivity;

    private float xRotation = 0f;

    private float minRotation;
    private float maxRotation;

    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        Debug.Log(mouseY);

        //control rotation around x axis (Look up and down)
        xRotation -= mouseY;

        //we clamp the rotation so we cant Over-rotate (like in real life)
        ToggleCam toggleCam = FindObjectOfType<ToggleCam>();


        if (toggleCam.FirstPersonState())
        {
            minRotation = -80f;
            maxRotation = 80f;
        }
        else if (toggleCam.ThirdPersonState())
        {
            minRotation = -30f;
            maxRotation = 30f;
        }
        else
        {
            minRotation = -90f;
            maxRotation = 90f;
        }

        xRotation = Mathf.Clamp(xRotation, minRotation, maxRotation);

        //applying x rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

    }
}