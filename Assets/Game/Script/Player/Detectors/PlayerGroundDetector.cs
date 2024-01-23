using UnityEngine;

public class PlayerGroundDetector : MonoBehaviour
{
    [SerializeField] float detectionRadius = 0.1f;

    [SerializeField] LayerMask groundLayer;

    Collider2D[] colliders = new Collider2D[1];

    public int numGrounds => Physics2D.OverlapCircleNonAlloc(transform.position, detectionRadius, colliders, groundLayer);
    public bool isGrounded => numGrounds > 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
