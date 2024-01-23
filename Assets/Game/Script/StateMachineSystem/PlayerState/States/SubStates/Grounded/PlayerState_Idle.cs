using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerGroundedState
{
    [SerializeField] float deacceleration = 10f;

    float currentSpeed;
    public override void Enter()
    {
        base.Enter();
        animator.Play("Idle_test");
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (input.Move)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }
        currentSpeed = Mathf.MoveTowards(playerMovement.currentSpeedX, 0f, deacceleration * Time.deltaTime);
        if (!playerMovement.isGrounded && playerMovement.isFalling)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }

    }
    public override void PhysicUpdate()
    {
        playerMovement.Move(currentSpeed);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
