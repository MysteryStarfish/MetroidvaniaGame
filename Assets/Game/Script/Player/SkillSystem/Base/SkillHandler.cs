using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SkillHandler : MonoBehaviour
{
    private SkillHandler skillHandler;
    private PlayerMovement playerMovement;
    private PlayerInput input;
    private Skill activateSkill;
    [SerializeField] public Skill[] skills;
    public Dictionary<System.Type, Skill> skillTable;

    private void Activate(Skill skill)
    {
        if (activateSkill)
        {
            activateSkill.BeginCooldown();
            activateSkill.Finish();
        }
        
        activateSkill = skill;
        StopCoroutine(nameof(Run));
        StartCoroutine(nameof(Run));
    }
    IEnumerator Run()
    {
        activateSkill.Activate();
        yield return new WaitForSeconds(activateSkill.activeTime);
        activateSkill.BeginCooldown();
        yield return new WaitForSeconds(activateSkill.cooldownTime);
        activateSkill.Finish();
        activateSkill = null;
    }

    private void Awake()
    {
        skillTable = new Dictionary<System.Type, Skill> (skills.Length);
        skillHandler = GetComponent<SkillHandler>();
        playerMovement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();
        foreach (Skill skill in skills)
        {
            skill.Initialize(playerMovement, input, skillHandler);
            skillTable.Add(skill.GetType(), skill);
            skill.isCooldown = false;
        }
    }
    private void Update()
    {
        if (input.Dash && !skillTable[typeof(PlayerSkill_Dash)].isCooldown)
        {
            Activate(skillTable[typeof(PlayerSkill_Dash)]);
        }
        if ((input.Jump || input.hasJumpBuffer) && playerMovement.canJump && !playerMovement.wallJumpTrigger && !skillTable[typeof(PlayerSkill_Jump)].isCooldown)
        {
            Activate(skillTable[typeof(PlayerSkill_Jump)]);
        }
        if ((input.Jump || input.hasJumpBuffer) && playerMovement.wallJumpTrigger && !skillTable[typeof(PlayerSkill_WallJump)].isCooldown)
        {
            Activate(skillTable[typeof(PlayerSkill_WallJump)]); 
        }
    }
}
