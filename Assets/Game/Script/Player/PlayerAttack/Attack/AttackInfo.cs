using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackInfo : Attack
{
    public override IEnumerator Cast()
    {
        return base.Cast();
    }
    public override IEnumerator AttackDurationTime()
    {
        return base.AttackDurationTime();
    }
    public override IEnumerator BackSwing()
    {
        return base.BackSwing();
    }
    public override IEnumerator CoolDown()
    {
        return base.CoolDown();
    }
    public override void HitboxActive()
    {
        base.HitboxActive();
    }
    public override void HitboxOff()
    {
        base.HitboxOff();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            hitEnemy = true;
            enemy = collision.gameObject.GetComponent<Enemy>();
        }
    }
}