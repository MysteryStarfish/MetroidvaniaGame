using UnityEngine;

public class Bullet : MonoBehaviour
{
    public PlayerHandler player = null;
    private Rigidbody2D rb;
    public float toward;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Summon()
    {
        this.transform.position = transform.position;
        this.gameObject.SetActive(true);
        rb.velocity = new Vector3(toward * 20f, 0f);
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
