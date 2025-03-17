using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private bool playerInteract;

    private bool isPointing;

    // Start is called before the first frame update
    void Start()
    {
        playerInteract = false;

        isPointing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            playerInteract = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            isPointing = true;
        }
        else
        {
            isPointing = false;
        }
    }

    public bool IsPointing()
    {
        return isPointing;
    }
}
