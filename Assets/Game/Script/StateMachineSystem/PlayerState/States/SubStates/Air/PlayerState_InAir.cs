using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/InAir", fileName = "PlayerState_InAir")]
public class PlayerState_InAir : PlayerAirState
{
    public override void Enter()
    {
        base.Enter();
        animator.Play("Jump");
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerMovement.isFalling || input.StopJump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
    public override void Exit()
    {
        base.Exit();
    }
}
