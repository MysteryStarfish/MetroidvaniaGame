using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using UnityEditor.VersionControl;
using UnityEngine;
using static Cinemachine.CinemachineBlendDefinition;

public abstract class Enemy : MonoBehaviour
{
    EnemyData data;

    PlayerDetector playerDetector;

    public EnemySkillHandler enemySkillHandler;

    public bool isPlayerAround => playerDetector.isPlayerAround;
    public bool hasFinishSkill => enemySkillHandler.hasFinishSkill;
    public bool isMeleeTrigger => enemySkillHandler.isMeleeTrigger || enemySkillHandler.isFireTrigger;
    public bool isReadyForSkill = false;
    
    public float currentHp;
    public float currentDamage;

    private void Awake()
    {
        data = GetComponent<EnemyData>();
        playerDetector = GetComponentInChildren<PlayerDetector>();
        enemySkillHandler = GetComponentInChildren<EnemySkillHandler>();

        currentHp = data.maxHp;
        currentDamage = data.damage;
    }
    public void Update()
    {
        if (currentHp <= 0)
        {
            KillSelf();
        }
    }
    public void TakeDamage(float damage)
    {
        currentHp -= damage;
    }
    public void KillSelf()
    {
        Destroy(gameObject);
    }
    public void UseSkill()
    {
        enemySkillHandler.SkillUpdate();
    }
}
