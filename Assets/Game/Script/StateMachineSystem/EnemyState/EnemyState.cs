using UnityEngine;

public class EnemyState : ScriptableObject, IState
{
    protected EnemyStateMachine enemyStateMachine;
    protected EnemyMovement enemyMovement;
    protected Enemy enemy;
    protected Animator animator;
    public void Initialize(Enemy enemy, EnemyMovement enemyMovement, Animator animator, EnemyStateMachine enemyStateMachine)
    {
        this.enemy = enemy;
        this.enemyStateMachine = enemyStateMachine;
        this.enemyMovement = enemyMovement;
        this.animator = animator;
    }
    public virtual void Enter()
    {
        Debug.Log(this.name);
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
