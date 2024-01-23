using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SkillSystem/EnemySkill/MeleeSpecial", fileName = "EnemySkill_MeleeSpecial")]
public class EnemySkill_MeleeSpecial : EnemySkill
{
    [SerializeField] private float dashSpeed = 40f;
    [SerializeField] private float jumpSpeed = 40f;

    private bool canHurtPlayer = false;

    PlayerDetector_Melee playerDetector_Melee;
    public override void SkillAwake()
    {
        playerDetector_Melee = enemySkillHandler.transform.GetChild(1).GetComponent<PlayerDetector_Melee>();
    }
    public override void StartAttack()
    {
        base.StartAttack();
        enemySkillHandler.transform.GetChild(1).gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 255));
        enemy.gameObject.GetComponent<SpriteRenderer>().color = (Color)(new Color32(187, 25, 0, 255));
    }
    public override void FinishAttack()
    {
        base.StartAttack();
        enemySkillHandler.transform.GetChild(1).gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(0, 0, 0, 0));
        enemy.gameObject.GetComponent<SpriteRenderer>().color = (Color)(new Color32(231, 194, 0, 255));
    }
    public override void ActivateAttack()
    {
        enemySkillHandler.transform.GetChild(1).gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(225, 246, 0, 255));
        base.ActivateAttack();
        canHurtPlayer = true;
        enemyMovement.DashJump(dashSpeed, jumpSpeed);
    }
    public override void OffAttack()
    {
        enemySkillHandler.transform.GetChild(1).gameObject.GetComponentInChildren<SpriteRenderer>().color = (Color)(new Color32(255, 255, 255, 255));
        base.OffAttack();
        canHurtPlayer = false;
        enemyMovement.DashJump(5, -7);
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
