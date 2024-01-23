using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    private WaitForSeconds waitJumpInputBufferTime;
    private float jumpInputBufferTime = 0.25f;

    Vector2 axes => playerInputActions.GamePlay.Axes.ReadValue<Vector2>();

    public bool hasJumpBuffer = false;
    public bool Jump => playerInputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputActions.GamePlay.Jump.WasReleasedThisFrame();
    public bool Move => AxisX != 0f;
    public bool Attack => playerInputActions.GamePlay.Attack.WasPressedThisFrame();
    public bool Dash => playerInputActions.GamePlay.Dash.WasPressedThisFrame();

    public float AxisX => axes.x;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();

        waitJumpInputBufferTime = new WaitForSeconds(jumpInputBufferTime);
    }
    public void EnablePlayerInput()
    {
        playerInputActions.GamePlay.Enable();
        // Cursor.lockState = CursorLockMode.Locked;
    }
    public void DisablePlayerInput()
    {
        playerInputActions.GamePlay.Disable();

    }
    public void SetJumpInputBufferTimer()
    {
        StopCoroutine(JumpInputBufferCoroutine());
        StartCoroutine(JumpInputBufferCoroutine());
    }
    IEnumerator JumpInputBufferCoroutine()
    {
        hasJumpBuffer = true;
        yield return waitJumpInputBufferTime;
        hasJumpBuffer = false;
    }
    private void OnGUI()
    {
        Rect rect = new Rect(200, 200, 200, 200);

        string message = "hasJumpBuffer : " + hasJumpBuffer;

        GUIStyle style = new GUIStyle();
        style.fontSize = 50;
        style.fontStyle = FontStyle.Bold;
        style.normal.textColor = Color.white;

        GUI.Label(rect, message, style);
    }
}
