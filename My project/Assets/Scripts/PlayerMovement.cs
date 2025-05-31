using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private bool isGrounded;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        ProcessInput();
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ProcessInput()
    {
        moveInput = Vector2.zero;

        if (Keyboard.current[Key.A].isPressed || Keyboard.current[Key.LeftArrow].isPressed)
        {
            moveInput.x = -1f;
        }
        else if (Keyboard.current[Key.D].isPressed || Keyboard.current[Key.RightArrow].isPressed)
        {
            moveInput.x = 1f;
        }
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        if (moveInput.x < 0)
            spriteRenderer.flipX = true;
        else if (moveInput.x > 0)
            spriteRenderer.flipX = false;
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if ((Keyboard.current[Key.W].wasPressedThisFrame || Keyboard.current[Key.UpArrow].wasPressedThisFrame) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Optional: visualize the ground check in editor
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
        }
    }
}
