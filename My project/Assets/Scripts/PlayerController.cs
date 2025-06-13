using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 7f;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Use the player's position for ground check
        isGrounded = Physics2D.OverlapCircle(transform.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            PerformJump();
        }
        else if (!isGrounded && jumpCount < (GameManager.HasDoubleJump ? 2 : 1) && Input.GetButtonDown("Jump"))
        {
            PerformJump();
        }
    }

    void PerformJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount++;
    }

    void LateUpdate()
    {
        if (isGrounded)
        {
            jumpCount = 0;
        }
    }
}
