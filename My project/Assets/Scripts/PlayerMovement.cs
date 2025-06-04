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
    private SpriteRenderer spriteRenderer;

    private bool isGrounded = false;
    [SerializeField] private bool isMaze = false;

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

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void ProcessInput()
    {
        moveInput = Vector2.zero;

        if (Keyboard.current[Key.A].isPressed || Keyboard.current[Key.LeftArrow].isPressed)
        {
            spriteRenderer.flipX = true;
            moveInput.x = -1f;
        }
        else if (Keyboard.current[Key.D].isPressed || Keyboard.current[Key.RightArrow].isPressed)
        {
            spriteRenderer.flipX = false;
            moveInput.x = 1f;
        }
    }

    private void Move()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);

        if ((Keyboard.current[Key.W].wasPressedThisFrame || Keyboard.current[Key.UpArrow].wasPressedThisFrame) && isGrounded && !isMaze)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, 0.1f);
        }
    }
}
