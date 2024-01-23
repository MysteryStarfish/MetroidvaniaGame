using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Climb", fileName = "PlayerState_Climb")]
public class PlayerState_Climb : PlayerWallState
{
    [SerializeField] float wallFallSpeed = 0.3f;
    public override void Enter()
    {
        base.Enter();
        playerMovement.Grounded();
    }
    public override void LogicUpdate()
    {
        if (playerMovement.isGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Land));
        }
        if (!playerMovement.isClimbing)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
        if (input.Jump || input.hasJumpBuffer)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_WallJump));
        }
    }
    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        playerMovement.Fall(wallFallSpeed);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
