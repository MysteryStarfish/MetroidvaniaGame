using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Land", fileName = "PlayerState_Land")]
public class PlayerState_Land : PlayerGroundedState
{
    [SerializeField] float stiffTimeTimes = 0.02f;
    float stiffTime;
    public override void Enter()
    {
        // TODO: animetion
        base.Enter();
        playerMovement.Grounded();
        playerMovement.Move(0);
        stiffTime = playerMovement.currentSpeedY * stiffTimeTimes;
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (StateDuration < stiffTime) 
        {
            return;
        }

        if (input.Move)
        {
            playerStateMachine.SwitchState(typeof(PlayerState_Run));
        }

        playerStateMachine.SwitchState(typeof(PlayerState_Idle));
    }
    public override void Exit()
    {
        base.Exit();
    }
}
