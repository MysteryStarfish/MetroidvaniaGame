using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemySkillHandler : MonoBehaviour
{
    public bool isMeleeTrigger => playerDetector_Melee.isMeleeTrigger;
    public bool isFireTrigger => playerDetector_Fire.isMeleeTrigger;

    public bool hasFinishSkill;
    public bool isSkillCooldown => !((isFireTrigger && !skillTable[typeof(EnemySkill_Fire)].isCooldown) ||
                                    (isMeleeTrigger && !skillTable[typeof(EnemySkill_Melee)].isCooldown));

    [SerializeField] public EnemySkill[] skills;

    EnemySkill_Melee enemySkill_Melee;
    EnemySkill_MeleeSpecial enemySkill_MeleeSpecial;
    EnemySkill enemySkill_Fire;
    EnemySkill enemySkill_Special;
    EnemySkill currentSkill;

    Enemy enemy;
    EnemyMovement enemyMovement;
    PlayerDetector_Melee playerDetector_Melee;
    PlayerDetector_Melee playerDetector_Fire;

    private float fireCoolDown;
    private float useFireTime;
    private int finishSkillNum;
    private int currentSkillNum;
    private Dictionary<System.Type, EnemySkill> skillTable;
    
    private void Awake()
    {
        enemy = GetComponentInParent<Enemy>();
        enemyMovement = GetComponentInParent<EnemyMovement>();

        skillTable = new Dictionary<System.Type, EnemySkill>(skills.Length);

        foreach (EnemySkill skill in skills)
        {
            skill.Initialize(enemy, enemyMovement, this);
            skill.SkillAwake();
            skill.isCooldown = false;
            skillTable.Add(skill.GetType(), skill);
        }

        playerDetector_Melee = GetComponentInChildren<PlayerDetector_Melee>();
        playerDetector_Fire = transform.GetChild(2).GetComponent<PlayerDetector_Melee>();

        hasFinishSkill = true;
    }
    private void Update()
    {
        if (currentSkill) currentSkill.Update();
    }
    public void SkillUpdate()
    {
        if (isFireTrigger && hasFinishSkill && !skillTable[typeof(EnemySkill_CarrotRain)].isCooldown)
        {
            Debug.Log("CarrotRain");
            StopCoroutine(nameof(CarrotRain));
            StartCoroutine(nameof(CarrotRain));
        }
        else if (isFireTrigger && hasFinishSkill && !skillTable[typeof(EnemySkill_Fire)].isCooldown)
        {
            Debug.Log("Fire");
            StopCoroutine(nameof(Fire));
            StartCoroutine(nameof(Fire));
        }
        else if (isMeleeTrigger && hasFinishSkill && !skillTable[typeof(EnemySkill_Melee)].isCooldown)
        {
            if (Random.value < 0.25f)
            {
                Debug.Log("MeleeCombo");
                StopCoroutine(nameof(MeleeCombo));
                StartCoroutine(nameof(MeleeCombo));
            }
            else
            {
                Debug.Log("Melee");
                StopCoroutine(nameof(Melee));
                StartCoroutine(nameof(Melee));
            }
        }
        else if (isMeleeTrigger && hasFinishSkill)
        {
            Debug.Log("MeleeNormal");
            StopCoroutine(nameof(MeleeNormal));
            StartCoroutine(nameof(MeleeNormal));
        }
    }
    private void SwitchSkill(EnemySkill skill)
    {
        currentSkill = skill;
    }
    public void SwitchSkill(System.Type skill)
    {
        SwitchSkill(skillTable[skill]);
    }
    private IEnumerator UseSkill(System.Type skill)
    {
        enemyMovement.TurnToPlayer();
        SwitchSkill(skillTable[skill]);
        yield return AttackIEnumerator();
    }
    private IEnumerator MeleeCombo()
    {
        hasFinishSkill = false;

        yield return UseSkill(typeof(EnemySkill_Melee));

        yield return UseSkill(typeof(EnemySkill_Melee));

        yield return UseSkill(typeof(EnemySkill_MeleeSpecial));

        hasFinishSkill = true;

        StartCoroutine(nameof(Cooldown));
    }
    private IEnumerator Melee()
    {
        hasFinishSkill = false;

        yield return UseSkill(typeof(EnemySkill_Melee));

        hasFinishSkill = true;

        StartCoroutine(nameof(Cooldown));
    }
    private IEnumerator MeleeNormal()
    {
        hasFinishSkill = false;

        yield return UseSkill(typeof(EnemySkill_MeleeNormal));

        hasFinishSkill = true;

        StartCoroutine(nameof(Cooldown));
    }
    private IEnumerator Fire()
    {
        hasFinishSkill = false;

        yield return UseSkill(typeof(EnemySkill_Fire));

        hasFinishSkill = true;

        StartCoroutine(nameof(Cooldown));
    }
    private IEnumerator CarrotRain()
    {
        hasFinishSkill = false;

        yield return UseSkill(typeof(EnemySkill_CarrotRain));

        yield return UseSkill(typeof(EnemySkill_CarrotRain));

        yield return UseSkill(typeof(EnemySkill_CarrotRain));

        hasFinishSkill = true;

        StartCoroutine(nameof(Cooldown));
    }
    private IEnumerator Cooldown()
    {
        yield return currentSkill.Cooldown();
    }
    private IEnumerator AttackIEnumerator()
    {
        return currentSkill.AttackIEnumerator();
    }
    public void OnGUI()
    {
        Rect rect = new Rect(200, 250, 200, 200);

        string message = "isFireTrigger : " + (isMeleeTrigger && hasFinishSkill && !skillTable[typeof(EnemySkill_Melee)].isCooldown);

        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;

        GUI.Label(rect, message, style);
    }
}
