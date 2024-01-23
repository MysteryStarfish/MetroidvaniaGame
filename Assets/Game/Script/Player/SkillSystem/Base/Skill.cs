using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class Skill : ScriptableObject
{
    protected SkillHandler skillHandler;

    protected PlayerMovement playerMovement;

    protected PlayerInput input;

    protected PlayerData playerData;

    protected string skillName;
    protected float startCooldownTime;
    public float cooldownTime;
    public float activeTime;

    public bool isCooldown = false;

    public virtual void Initialize(PlayerMovement playerMovement, PlayerInput input, SkillHandler skillHandler)
    {
        this.skillHandler = skillHandler;
        this.playerMovement = playerMovement;
        this.input = input;
    }
    public virtual void Activate() 
    {

    }
    public virtual void BeginCooldown()
    {
        isCooldown = true;
    }
    public virtual void Finish()
    {
        isCooldown = false;
    }
}
