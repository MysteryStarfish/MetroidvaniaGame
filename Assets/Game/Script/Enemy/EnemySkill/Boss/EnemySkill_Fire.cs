using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SkillSystem/EnemySkill/Fire", fileName = "EnemySkill_Fire")]
public class EnemySkill_Fire : EnemySkill
{
    private bool canHurtPlayer = false;

    PlayerDetector_Melee playerDetector_Melee;
    bullet bullet;
    public override void SkillAwake()
    {
        playerDetector_Melee = enemySkillHandler.transform.GetChild(2).GetComponent<PlayerDetector_Melee>();
        bullet = enemySkillHandler.transform.GetChild(3).GetComponent<bullet>();
    }
    public override void StartAttack()
    {
        base.StartAttack();
        enemySkillHandler.transform.GetChild(2).gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 255));
        enemy.gameObject.GetComponent<SpriteRenderer>().color = (Color)(new Color32(187, 25, 0, 255));
    }
    public override void FinishAttack()
    {
        base.FinishAttack();
        enemySkillHandler.transform.GetChild(2).gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(0, 0, 0, 0));
        enemy.gameObject.GetComponent<SpriteRenderer>().color = (Color)(new Color32(231, 194, 0, 255));
    }
    public override void ActivateAttack()
    {
        enemySkillHandler.transform.GetChild(2).gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(225, 246, 0, 255));
        base.ActivateAttack();
        canHurtPlayer = true;
        bullet.Summon();
    }
    public override void OffAttack()
    {
        enemySkillHandler.transform.GetChild(2).gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 255));
        base.OffAttack();
        canHurtPlayer = false;
        bullet.Recycle(enemySkillHandler.transform);
    }
    public override void Update()
    {
        base.Update();
        if (bullet.player && canHurtPlayer)
        {
            canHurtPlayer = false;
            playerDetector_Melee.player.TakeDamage(enemy.currentDamage);
            bullet.Recycle(enemySkillHandler.transform);
        }
    }
}
