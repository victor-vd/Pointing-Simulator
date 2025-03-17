using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerAnimator : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;

    private Player player;

    [SerializeField] private PlayerMovement playerMovement;

    private PointAim[] pointAim;

    private float walkingSpeed;

    private bool isPointing;

    private bool isWalking;

    int currentFrame, motionStartFrame;

    void Awake()
    {
        animator = GetComponent<Animator>();

        player = FindObjectOfType<Player>();

        pointAim = FindObjectsOfType<PointAim>();
    }

    void Update()
    {
        currentFrame += 1;

        walkingSpeed = playerMovement.SprintFactor();

        isWalking = playerMovement.IsWalking();

        isPointing = player.IsPointing();

        if (walkingSpeed > 1)
        {
            walkingSpeed -= 0.5f;
        }

        animator.SetBool("isWalking", isWalking);

        animator.SetFloat("sprintFactor", walkingSpeed);

        if (player != null)
        {
            animator.SetBool("isPointing", isPointing);

            if (isPointing && !isWalking)
            {
                for (int i = 0; i < pointAim.Length; i++)
                {
                    pointAim[i].StartWeight();
                }
                motionStartFrame = currentFrame;
            }
            else if (currentFrame - motionStartFrame >= 300)
            {
                for (int i = 0; i < pointAim.Length; i++)
                {
                    pointAim[i].CancelWeight();
                }
            }
        }
    }
}