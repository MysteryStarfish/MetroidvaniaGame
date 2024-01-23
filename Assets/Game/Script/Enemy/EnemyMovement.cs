using UnityEngine;
using UnityEngine.Windows;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D rb;

    Transform player;

    EnemyData enemyData;

    public int faceDiretion => (int)(transform.localScale.x / Mathf.Abs(transform.localScale.x));
    public float currentSpeed => rb.velocity.x;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemyData = GetComponent<EnemyData>();
    }

    private void TurnDirection(int faceDirection)
    {
        if (faceDirection == 0) return;
        transform.localScale = new Vector3(faceDirection * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    private void TurnCurrentDirection()
    {
        int currentFaceDirection = (int)(rb.velocity.x / Mathf.Abs(rb.velocity.x));
        TurnDirection(currentFaceDirection);
    }
    public void TurnToPlayer()
    {
        if (rb.position.x - player.position.x == 0) return;
        int direction = -(int)((rb.position.x - player.position.x) / Mathf.Abs(rb.position.x - player.position.x));
        TurnDirection(direction);
    }
    public void Move(float speed)
    {
        SetVelocityX(speed * faceDiretion);
    }
    public void Dash(float speed)
    {
        SetVelocityX(speed * faceDiretion);
    }
    public void MoveToPlayerPosX()
    {
        TurnToPlayer();
        Move(enemyData.runSpeed);
    }
    public void Jump(float speed)
    {
        SetVelocityY(speed);
    }
    public void DashJump(float speedX, float speedY)
    {
        Vector3 velocity = new Vector3(speedX * faceDiretion, speedY);
        SetVelocity(velocity);
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
}
