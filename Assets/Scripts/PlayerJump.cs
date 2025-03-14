using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    private bool Jumping = false;
    private Rigidbody2D _rigidbody;
    public float JumpForce = 5f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            Jumping = true;
        }
    }

    private void FixedUpdate()
    {
        if (Jumping == true)
        {
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            Jumping = false;
        }
    }
}