using UnityEngine;

public class WormBehaviour: MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;     // Geschwindigkeit
    [SerializeField] private float flipInterval = 3f;                   // Wie oft die Richtung gewechselt wird 

    private Rigidbody2D rb;
    private bool movingRight = true;
    private float flipTimer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flipTimer = flipInterval;
    }

    void Update()
    {
        // Gegner bewegt sich nach rechts oder links
        float direction = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * moveSpeed, rb.linearVelocity.y);

        flipTimer -= Time.deltaTime;
        if (flipTimer <= 0f)
        {
            Flip();
            flipTimer = flipInterval;
        }
    }

    void Flip()
    {
        movingRight = !movingRight;

        // Gegner dreht sich um
        Vector3 scale = transform.localScale;
        scale.x *= -1f;
        transform.localScale = scale;
    }
}
