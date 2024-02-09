using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Run", fileName = "PlayerState_Run")]
public class PlayerState_Run : PlayerGroundedState
{
    public override void Enter()
    {
        base.Enter();
        animator.Play("Run");
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        if (!input.Move)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Idle));
        }
        if (playerMovement.isFloating)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_CoyoteTime));
        }
    }
    public override void PhysicUpdate()
    {
        playerMovement.Move(playerMovement.runSpeed);
    }
    public override void Exit()
    {
        base.Exit();
    }
}
