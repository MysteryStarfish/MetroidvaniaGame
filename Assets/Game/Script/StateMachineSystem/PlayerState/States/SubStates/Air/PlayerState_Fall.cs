using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]
public class PlayerState_Fall : PlayerAirState
{
    [SerializeField] AnimationCurve speedCurve;
    public override void Enter()
    {
        base.Enter();
        animator.Play("Fall");
        playerMovement.Fall(0f);
        playerMovement.JumpUp();
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (playerMovement.isGrounded)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Land));
        }
        if (input.Jump && playerMovement.canJump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_InAir));
        }
        if (input.Jump && !playerMovement.canJump)
        {
            input.SetJumpInputBufferTimer();
        }
    }
    public override void PhysicUpdate()
    {

        base.PhysicUpdate();
        playerMovement.Fall(speedCurve.Evaluate(StateDuration));
    }
    public override void Exit()
    {
        base.Exit();
    }
}
