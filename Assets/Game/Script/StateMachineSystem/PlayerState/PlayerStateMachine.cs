using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [SerializeField] public PlayerState[] states;

    PlayerMovement playerMovement;

    PlayerInput input;

    Animator animator;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        input = GetComponent<PlayerInput>();
        stateTable = new Dictionary<System.Type, IState> (states.Length);
        animator = GetComponentInChildren<Animator> ();

        foreach (PlayerState state in states)
        {
            state.Initialize(playerMovement, input, animator, this);
            stateTable.Add(state.GetType(), state);
        }
    }
    private void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);
    }
}
