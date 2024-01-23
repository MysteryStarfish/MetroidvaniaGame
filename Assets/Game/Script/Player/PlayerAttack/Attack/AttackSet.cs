using System.Collections;
using UnityEngine;

public class AttackSet : MonoBehaviour
{
    [SerializeField] Attack[] attacks;

    public bool isCombo => attacks.Length-1 - currentAttackNum > 0;
    public int length => attacks.Length;

    public Attack currentAttack;

    public float finishAttackTime;
    public int currentAttackNum = 0;
    public bool hasFinishAttack = true;

    public virtual void Initialize()
    {
        hasFinishAttack = true;
        SetAttack(attacks[currentAttackNum]);
    }
    public virtual IEnumerator Run()
    {
        hasFinishAttack = false;
        yield return currentAttack.Cast();
        currentAttack.HitboxActive();
        yield return currentAttack.AttackDurationTime();
        currentAttack.HitboxOff();
        yield return currentAttack.BackSwing();
        yield return currentAttack.CoolDown();
        NextAttack();
        hasFinishAttack = true;
        finishAttackTime = Time.time;
    }
    protected virtual void NextAttack()
    {
        NextAttackNum();
        SetAttack(attacks[currentAttackNum]);
    }
    public virtual void NextAttackNum()
    {
        currentAttackNum++;
        currentAttackNum %= attacks.Length;
    }
    public void SetAttack(Attack attack)
    {
        currentAttack = attack;
    }
    public virtual void StopCombo()
    {
        currentAttackNum = 0;
        SetAttack(attacks[currentAttackNum]);
    }
}
