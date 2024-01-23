using System.Collections;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] protected float attackTime;
    [SerializeField] protected float castTime;
    [SerializeField] protected float backSwingTime;
    [SerializeField] protected float cooldownTime;

    public bool hitEnemy = false;
    public float comboWaitingTime;
    public Enemy enemy;
    public virtual void HitboxActive()
    {
        this.gameObject.SetActive(true);
    }
    public virtual void HitboxOff()
    {
        this.gameObject.SetActive(false);
    }
    public virtual IEnumerator Cast()
    {
        yield return new WaitForSeconds(castTime);
    }
    public virtual IEnumerator BackSwing()
    {
        yield return new WaitForSeconds(backSwingTime);
    }
    public virtual IEnumerator AttackDurationTime()
    {
        yield return new WaitForSeconds(attackTime);
    }
    public virtual IEnumerator CoolDown()
    {
        yield return new WaitForSeconds(cooldownTime);
    }
}
