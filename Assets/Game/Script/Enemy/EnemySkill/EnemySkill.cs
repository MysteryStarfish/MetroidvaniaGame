using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySkill : ScriptableObject
{
    [SerializeField] private float castTime;
    [SerializeField] private float activeTime;
    [SerializeField] private float backswingTime;
    [SerializeField] private float cooldownTime;

    public bool isCooldown = false;

    protected Enemy enemy;
    protected EnemyMovement enemyMovement;
    protected EnemySkillHandler enemySkillHandler;
    public void Initialize(Enemy enemy, EnemyMovement enemyMovement, EnemySkillHandler enemySkillHandler)
    {
        this.enemy = enemy;
        this.enemyMovement = enemyMovement;
        this.enemySkillHandler = enemySkillHandler;
    }
    public IEnumerator Cast()
    {
        yield return new WaitForSeconds(castTime);
    }
    public IEnumerator DuringActive()
    {
        yield return new WaitForSeconds(activeTime);
    }
    public IEnumerator Backswing()
    {
        yield return new WaitForSeconds(backswingTime);
    }
    public IEnumerator Cooldown()
    {
        this.isCooldown = true;
        yield return new WaitForSeconds(cooldownTime);
        this.isCooldown = false;
    }
    public IEnumerator AttackIEnumerator()
    {
        StartAttack();
        yield return Cast();
        ActivateAttack();
        yield return DuringActive();
        OffAttack();
        yield return Backswing();
        FinishAttack();
    }
    public virtual void StartAttack()
    {

    }
    public virtual void FinishAttack()
    {

    }
    public virtual void ActivateAttack()
    {

    }
    public virtual void OffAttack()
    {

    }
    public virtual void SkillAwake()
    {

    }
    public virtual void Update()
    {

    }
}
