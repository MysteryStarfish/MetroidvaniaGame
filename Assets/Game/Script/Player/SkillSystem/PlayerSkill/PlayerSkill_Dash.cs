using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/SkillSystem/PlayerSkill/Dash", fileName = "PlayerSkill_Dash")]
public class PlayerSkill_Dash : Skill
{
    [SerializeField] private float dashSpeed;
    public override void Activate()
    {
        base.Activate();
        playerMovement.DashOn();
        playerMovement.SetVelocityX(dashSpeed * playerMovement.faceDiretion);
        playerMovement.SetGravity(false);
        playerMovement.SetVelocityY(0);
    }
    public override void BeginCooldown()
    {
        base.BeginCooldown();
        playerMovement.DashOff();
        playerMovement.SetVelocityX(0);
        playerMovement.SetGravity(true);
    }
    public override void Finish()
    {
        base.Finish();
    }
}
