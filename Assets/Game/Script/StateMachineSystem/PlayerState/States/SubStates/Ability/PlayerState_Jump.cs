using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Jump", fileName = "PlayerState_Jump")]
public class PlayerState_Jump : PlayerAirState
{
    [SerializeField] AnimationCurve speedCurve;
    public override void Enter()
    {
        base.Enter();
    }
    public override void LogicUpdate()
    {
        if (playerMovement.isFalling || input.StopJump)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Fall));
        }
    }
    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        playerMovement.Jump(speedCurve.Evaluate(StateDuration));
    }
}
