using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(menuName = "Data/SkillSystem/PlayerSkill/WallJump", fileName = "PlayerSkill_WallJump")]
public class PlayerSkill_WallJump : Skill
{
    [SerializeField] float XSpeed;
    [SerializeField] float YSpeed;
    public override void Activate()
    {
        base.Activate();
        playerMovement.wallJumpTrigger = false;
        Vector3 speed = new Vector3(-playerMovement.faceDiretion * XSpeed, YSpeed, 0);
        playerMovement.SetVelocity(speed);
        playerMovement.TurnOtherDirection();
    }
    public override void BeginCooldown()
    {
        base.BeginCooldown();
    }
    public override void Finish()
    {
        base.Finish();
    }
}
