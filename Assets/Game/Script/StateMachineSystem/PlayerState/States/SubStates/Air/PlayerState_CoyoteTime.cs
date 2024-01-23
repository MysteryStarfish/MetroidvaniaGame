using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/CoyoteTime", fileName = "PlayerState_CoyoteTime")]
public class PlayerState_CoyoteTime : PlayerAirState
{
    [SerializeField] float coyoteTime = 0.3f;
    public override void Enter()
    {
        base.Enter();
        playerMovement.Fall(0f);
        playerMovement.SetGravity(false);
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerMovement.isJumping)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_InAir));
        }
        if (StateDuration > coyoteTime)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        playerMovement.Move(playerMovement.currentSpeedX);
    }
    public override void Exit()
    {
        base.Exit();
        playerMovement.SetGravity(true);
    }
}
