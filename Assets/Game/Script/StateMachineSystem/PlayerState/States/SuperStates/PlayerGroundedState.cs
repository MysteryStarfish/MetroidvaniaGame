using UnityEngine;

public class PlayerGroundedState : PlayerState
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
        if (input.Jump || input.hasJumpBuffer)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_InAir));
        }
    }
    public override void PhysicUpdate()
    {

    }
}
