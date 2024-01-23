using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] public EnemyState[] states;

    EnemyMovement enemyMovement;

    Enemy enemy;

    Animator animator;
    private void Awake()
    {
        enemyMovement = GetComponent<EnemyMovement>();
        enemy = GetComponent<Enemy>();
        animator = GetComponentInChildren<Animator>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (EnemyState state in states)
        {
            state.Initialize(enemy, enemyMovement, animator, this);
            stateTable.Add(state.GetType(), state);
        }
    }
    private void Start()
    {
        SwitchOn(states[0]);
    }
}
