using UnityEngine;
using UnityEngine.Windows;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Idle", fileName = "EnemyState_Idle")]
public class EnemyState_Idle : EnemyState
{
    [SerializeField] float deacceleration = 10f;

    float currentSpeed;
    public override void Enter()
    {
        base.Enter();
    }
    public override void LogicUpdate()
    {
        if (enemy.isPlayerAround)
        {
            enemyStateMachine.SwitchState(typeof(EnemyState_Track));
        }
        currentSpeed = Mathf.MoveTowards(enemyMovement.currentSpeed, 0f, deacceleration * Time.deltaTime);
    }
    public override void PhysicUpdate()
    {
        enemyMovement.Move(currentSpeed);
    }
}
