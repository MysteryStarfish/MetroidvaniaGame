using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallState : PlayerState
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

    }
    public override void PhysicUpdate()
    {
        if (input.AxisX/Mathf.Abs(input.AxisX) != playerMovement.faceDiretion)
        {
            playerMovement.Move(playerMovement.runSpeed);
        }
        playerMovement.Move(0);
    }
}
