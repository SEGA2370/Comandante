using UnityEngine;

internal static class GlobalStringVars
{
    #region Movement

    public const string HorizontalAxis = "Horizontal";
    public const string VerticalAxis = "Vertical";
    public const string Jump = "Jump";
    public const string Fire_1 = "Fire1";

    #endregion
}

[RequireComponent (typeof(PlayerMovement))]
[RequireComponent (typeof(Shooter))]


public class PlayerInput : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private Shooter shooter;
    private Animator animator;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        shooter = GetComponent<Shooter>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HorizontalAxis);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.Jump);

        if (Input.GetButtonDown(GlobalStringVars.Fire_1))
        {
            shooter.Shoot(horizontalDirection);
            animator.SetTrigger("Attack");
        }

        playerMovement.Move(horizontalDirection , isJumpButtonPressed);
    }
}
