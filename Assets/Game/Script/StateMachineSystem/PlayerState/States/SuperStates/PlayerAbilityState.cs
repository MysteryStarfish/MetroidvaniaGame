using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void Exit()
    {

    }
    public override void LogicUpdate()
    {
        if (input.Jump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Jump));
        }
        if (!playerMovement.isGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {

    }
}
