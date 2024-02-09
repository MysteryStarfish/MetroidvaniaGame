using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/WallJump", fileName = "PlayerState_WallJump")]
public class PlayerState_WallJump : PlayerWallState
{
    [SerializeField] AnimationCurve speedXCurve;
    [SerializeField] AnimationCurve speedYCurve;
    public override void Enter()
    {
        base.Enter();
        playerMovement.Grounded();
        playerMovement.wallJumpTrigger = true;
    }
    public override void LogicUpdate()
    {
        if (StateDuration < 0.4f)
        {
            return;
        }
        if (playerMovement.isFloating || playerMovement.isJumping)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_InAir));
        }
        if (playerMovement.isFalling)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {
        playerMovement.Fall(speedYCurve.Evaluate(StateDuration));
        if (StateDuration < 0.3f)
        {
            playerMovement.SetVelocityX(speedXCurve.Evaluate(StateDuration) * playerMovement.faceDiretion);
            return;
        }
        if (input.Move)
        {
            float speed = playerMovement.runSpeed + speedXCurve.Evaluate(StateDuration);
            if (speed >= playerMovement.runSpeed)
            {
                speed = playerMovement.runSpeed;
            }
            playerMovement.Move(speed);
        }
    }
    public override void Exit()
    {
        base.Exit();
    }
}
