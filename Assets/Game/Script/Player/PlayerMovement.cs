using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerGroundDetector playerGroundDetector;

    PlayerWallDetector playerWallDetector;

    PlayerData playerData;

    PlayerInput input;

    Rigidbody2D rb;

    AttakHandler attacker;

    private int jumpTimes = 0;
    public bool isDash;
    public float runSpeed => playerData.runSpeed;
    public float currentSpeedX => Mathf.Abs(rb.velocity.x);
    public float currentSpeedY => Mathf.Abs(rb.velocity.y);
    public float jumpSpeed => playerData.jumpSpeed;
    public int faceDiretion => (int)(transform.localScale.x/Mathf.Abs(transform.localScale.x));
    public bool isGrounded => playerGroundDetector.isGrounded;
    public bool isClimbing => playerWallDetector.isClimbing;
    public bool wallJumpTrigger = false;
    public bool isFalling => rb.velocity.y < 0 && !isGrounded;
    public bool isFloating => rb.velocity.y == 0 && !isGrounded;
    public bool isJumping => rb.velocity.y > 0;
    public bool canJump => jumpTimes < playerData.jumpTimesLimit;

    private void Awake()
    {
        playerWallDetector = GetComponentInChildren<PlayerWallDetector>();
        playerGroundDetector = GetComponentInChildren<PlayerGroundDetector>();
        attacker = GetComponentInChildren<AttakHandler>();
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        playerData = GetComponent<PlayerData>();
    }
    private void Start()
    {
        input.EnablePlayerInput();
    }
    private void TurnCurrentDirection()
    {
        int currentFaceDirection = (int)(input.AxisX / Mathf.Abs(input.AxisX));
        transform.localScale = new Vector3(currentFaceDirection * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    public void TurnOtherDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    public void Move(float speed)
    {
        int currentFaceDirection = input.AxisX != 0 ? (int)(input.AxisX / Mathf.Abs(input.AxisX)) : 1;
        if (isDash)
        {
            return;
        }
        if (input.Move && attacker.hasFinishAttack)
        {
            TurnCurrentDirection();
            currentFaceDirection = faceDiretion;
        }
        
        SetVelocityX(speed * currentFaceDirection);
    }
    public void Fall(float speed)
    {
        if (isDash)
        {
            return;
        }
        SetVelocityY(speed);
    }
    public void Jump(float force)
    {
        Vector2 jumpSpeed = new Vector2(0f, force);
        rb.AddForce(jumpSpeed);
        JumpUp();
    }
    public void Grounded()
    {
        jumpTimes = 0;
    }
    public void JumpUp()
    {
        jumpTimes += 1;
    }
    public void SetVelocity(Vector3 velocity)
    {
        rb.velocity = velocity;
    }
    public void SetVelocityX(float velocityX)
    {
        rb.velocity = new Vector3(velocityX, rb.velocity.y);
    }
    public void SetVelocityY(float velocityY)
    {
        rb.velocity = new Vector3(rb.velocity.x, velocityY);
    }
    public void SetGravity(bool value)
    {
        float gravityScale = value ? 1f : 0f;
        rb.gravityScale = gravityScale;
    }
    public void DashOn()
    {
        isDash = true;
    }
    public void DashOff()
    {
        isDash = false;
    }
}
