using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    [SerializeField] private PlayerMovement playerMovement;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isWalking", playerMovement.IsWalking());
    }
}