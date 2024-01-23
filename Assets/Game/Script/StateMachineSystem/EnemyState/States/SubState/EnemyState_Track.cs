using UnityEngine;


[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Track", fileName = "EnemyState_Track")]
public class EnemyState_Track : EnemyState
{
    public override void Enter()
    {
        base.Enter();
    }
    public override void LogicUpdate()
    {
        if (!enemy.isPlayerAround)
        {
            enemyStateMachine.SwitchState(typeof(EnemyState_Idle));
        }
        if (enemy.isMeleeTrigger && !enemy.enemySkillHandler.isSkillCooldown)
        {
            enemyStateMachine.SwitchState(typeof(EnemyState_Skill));
        }
    }
    public override void PhysicUpdate()
    {
        enemyMovement.MoveToPlayerPosX();
    }
}
