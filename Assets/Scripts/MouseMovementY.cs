using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovementY : MonoBehaviour
{
 
    public static float mouseSensitivity = 800f;
 
    float YRotation = 0f;
 
    void Start()
    {
        //Locking the cursor to the middle of the screen and making it invisible
        Cursor.lockState = CursorLockMode.Locked;
    }
 
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
 
        //control rotation around y axis (Look up and down)
        YRotation += mouseX;
 
        //applying y rotation
        transform.localRotation = Quaternion.Euler(0f, YRotation, 0f);
 
    }
}