using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    [SerializeField] private PlayerMovement playerMovement;

    private float walkingSpeed;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float walkingSpeed = playerMovement.SprintFactor();

        if (walkingSpeed > 1)
        {
            walkingSpeed -= 0.5f;
        }

        animator.SetBool("isWalking", playerMovement.IsWalking());
        animator.SetFloat("sprintFactor", walkingSpeed);
    }
}