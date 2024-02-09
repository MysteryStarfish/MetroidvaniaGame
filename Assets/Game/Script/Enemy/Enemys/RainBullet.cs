using UnityEngine;

public class RainBullet : MonoBehaviour
{
    public PlayerHandler player = null;
    private Rigidbody2D rb;
    public float toward;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Summon(Transform transform)
    {
        this.transform.position = transform.position + new Vector3(0f, 15f);
        this.gameObject.SetActive(true);
        rb.velocity = new Vector3(0f, -20f);
    }
    public void Recycle(Transform transform)
    {
        rb.velocity = new Vector3(0f, 0f);
        this.gameObject.SetActive(false);
        this.transform.position = transform.position;
        player = null;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Recycle(this.transform);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject.GetComponent<PlayerHandler>();
        }
    }
}
