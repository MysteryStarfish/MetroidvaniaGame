using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SkillSystem/EnemySkill/MeleeNormal", fileName = "EnemySkill_MeleeNormal")]
public class EnemySkill_MeleeNormal : EnemySkill
{
    private bool canHurtPlayer = false;

    PlayerDetector_Melee playerDetector_Melee;
    public override void SkillAwake()
    {
        playerDetector_Melee = enemySkillHandler.transform.GetComponentInChildren<PlayerDetector_Melee>();
    }
    public override void StartAttack()
    {
        base.StartAttack();
        enemySkillHandler.GetComponentInChildren<Transform>().gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 255));
        enemy.gameObject.GetComponent<SpriteRenderer>().color = (Color)(new Color32(187, 25, 0, 255));
    }
    public override void FinishAttack()
    {
        base.StartAttack();
        enemySkillHandler.GetComponentInChildren<Transform>().gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(0, 0, 0, 0));
        enemy.gameObject.GetComponent<SpriteRenderer>().color = (Color)(new Color32(231, 194, 0, 255));
    }
    public override void ActivateAttack()
    {
        enemySkillHandler.GetComponentInChildren<Transform>().gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(225, 246, 0, 255));
        base.ActivateAttack();
        canHurtPlayer = true;
    }
    public override void OffAttack()
    {
        enemySkillHandler.GetComponentInChildren<Transform>().gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 255));
        base.OffAttack();
        canHurtPlayer = false;
    }
    public override void Update()
    {
        base.Update();
        if (playerDetector_Melee.player && canHurtPlayer)
        {
            canHurtPlayer = false;
            playerDetector_Melee.player.TakeDamage(enemy.currentDamage);
        }
    }
}

