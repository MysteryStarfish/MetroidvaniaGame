using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/EnemyState/Skill", fileName = "EnemyState_Skill")]
public class EnemyState_Skill : EnemyState
{
    public override void Enter()
    {
        base.Enter();
        enemyMovement.Move(0);
    }
    public override void LogicUpdate()
    {
        enemy.UseSkill();
        if (enemy.hasFinishSkill)
        {
            enemyStateMachine.SwitchState(typeof(EnemyState_Idle));
        }
    }
    public override void PhysicUpdate()
    {
        
    }
}
