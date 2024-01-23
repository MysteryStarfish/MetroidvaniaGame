using UnityEngine;

public class PlayerAirState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void LogicUpdate()
    {
        if (playerMovement.isClimbing && input.Move && playerMovement.wallJumpTrigger == false)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Climb));
        }
    }
    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        if (input.Move)
        {
            playerMovement.Move(playerMovement.runSpeed);
        }
    }
}
