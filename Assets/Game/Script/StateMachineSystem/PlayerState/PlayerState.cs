using UnityEngine;

public class PlayerState : ScriptableObject, IState
{
    protected PlayerStateMachine playerStateMachine;

    protected PlayerMovement playerMovement;

    protected PlayerInput input;

    protected Animator animator;

    protected float stateStartTime;
    protected float StateDuration => Time.time - stateStartTime;
    public void Initialize(PlayerMovement playerMovement, PlayerInput input, Animator animator, PlayerStateMachine playerStateMachine)
    {
        this.playerStateMachine = playerStateMachine;
        this.playerMovement = playerMovement;
        this.input = input;
        this.animator = animator;
    }
    public virtual void Enter()
    {
        stateStartTime = Time.time;
    }

    public virtual void Exit()
    {
    }

    public virtual void LogicUpdate()
    {
        
    }

    public virtual void PhysicUpdate()
    {
        
    }
}
