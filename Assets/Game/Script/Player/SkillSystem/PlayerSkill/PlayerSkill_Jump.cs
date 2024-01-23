using UnityEngine;

[CreateAssetMenu(menuName = "Data/SkillSystem/PlayerSkill/Jump", fileName = "PlayerSkill_Jump")]
public class PlayerSkill_Jump : Skill
{
    [SerializeField] float force;
    public override void Activate()
    {
        base.Activate();
        playerMovement.SetVelocityY(force);
    }
    public override void BeginCooldown()
    {
        base.BeginCooldown();
        playerMovement.SetVelocityY(0);
    }
    public override void Finish()
    {
        base.Finish();
    }
}
