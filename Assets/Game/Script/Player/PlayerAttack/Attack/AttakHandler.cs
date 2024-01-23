using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttakHandler : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] AttackSet attackSet;

    PlayerInput input;

    [SerializeField] private bool bufferAttack;

    public bool hasFinishAttack => attackSet.hasFinishAttack;

    private void Awake()
    {
        input = GetComponentInParent<PlayerInput>();
        attackSet.Initialize();
        bufferAttack = false;
    }
    private void Update()
    {
        if (!attackSet.hasFinishAttack && !bufferAttack)
        {
            if (input.Attack)
            {
                bufferAttack = true;
            }
        }
        if (attackSet.hasFinishAttack)
        {
            if (input.Attack || bufferAttack)
            {
                bufferAttack = false;
                Attack();
            }
            if (Time.time - attackSet.finishAttackTime > attackSet.currentAttack.comboWaitingTime && attackSet.currentAttackNum > 0)
            {
                attackSet.StopCombo();
            }
        }
        if (attackSet.currentAttack.hitEnemy)
        {
            HitEnemy();
        }
    }
    private void Attack()
    {
        StopCoroutine(attackSet.Run());
        StartCoroutine(attackSet.Run());
    }
    void HitEnemy()
    {
        attackSet.currentAttack.hitEnemy = false;
        Debug.Log("hit");
        attackSet.currentAttack.enemy.TakeDamage(weapon.GetDamage());
    }
}
