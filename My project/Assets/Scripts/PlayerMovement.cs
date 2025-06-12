// using System.Runtime.CompilerServices;
// using UnityEngine;
// using UnityEngine.InputSystem;
// using UnityEngine.InputSystem.Interactions;
// using UnityEngine.UIElements;


// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     private Vector2 moveInput;
//     private SpriteRenderer mysprite;
//     // private Animator anim;
//     // private string ANIM = "Walk";
//     private Rigidbody2D mybody;
//     private float jumpforce = 10f;
//     private bool isGrounded = false;
//     // private string ANIMA = "Jump";
//     [SerializeField] private bool isMaze = false;

//     public void OnMove(InputValue value) // <-- Correct signature for Send Messages
//     {
//         moveInput = value.Get<Vector2>();
//     }


//     void Start()
//     {
//         mysprite = GetComponent<SpriteRenderer>();
//         // anim = GetComponent<Animator>();
//         mybody = GetComponent<Rigidbody2D>();
//     }
//     void Update()
//     {
//         Move();
//         Jump();
//     }

//     private void Move()
//     {

        

           
//             Vector3 movement;
//             if (isMaze)
//             {
//                 movement = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.deltaTime;
//             }
//             else
//             {
//                 movement = new Vector3(moveInput.x, 0f, 0f) * moveSpeed * Time.deltaTime;
//             }
//             transform.position += movement;

//             if (moveInput.x < 0)
//             {
//                 mysprite.flipX = true;
//             }

//             else if (moveInput.x > 0)
//             {
//                 mysprite.flipX = false;
//             }
//         }

//     private void Jump()
//     {
//         if ((Keyboard.current[Key.W].isPressed || Keyboard.current[Key.UpArrow].isPressed) && isGrounded)
//             if ((Keyboard.current[Key.W].isPressed || Keyboard.current[Key.UpArrow].isPressed) && isGrounded && !(isMaze))
//             {
//                 isGrounded = false;
//                 mybody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
//             }
//         if ((Keyboard.current[Key.S].isPressed || Keyboard.current[Key.DownArrow].isPressed) && isGrounded && !(isMaze))
//         {
//             isGrounded = false;
//             mybody.AddForce(new Vector2(0f, -1 * jumpforce), ForceMode2D.Impulse);
//         }
//     }

//     private void OnCollisionEnter2D(Collision2D collision)
//     {
//         if (collision.gameObject.CompareTag("Ground"))
//         {
//             isGrounded = true;
//         }
//     }
// }


using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private SpriteRenderer mysprite;
    private Rigidbody2D mybody;
    private Animator anim;
    private Transform mytransform;
    private string ANIM = "WALK";
    // private string ANIMA = "JUMP";
    private float jumpforce = 10f;
    private bool isGrounded = false;
    private int jumpCount = 0;
    private int maxJumps = 2; // Allows 1 jump from ground + 1 in air

    [SerializeField] private bool isMaze = false;

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void Start()
    {
        mysprite = GetComponent<SpriteRenderer>();
        mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        mytransform = GetComponent<Transform>();

        if (isMaze)
        {
            mybody.gravityScale = 0;
            Debug.Log("Maze mode active: Gravity disabled");
        }
        else
        {
            Debug.Log("Normal mode: Gravity enabled");
        }
    }


    void Update()
    {
        if (isMaze && mybody.gravityScale != 0)
        {
            mybody.gravityScale = 0;
            Debug.Log("Gravity forced to 0 in Update()");
        }

        Move();
        HandleJump();
        UpdateAnimationState();
    }

    private void Move()
    {
        Vector3 movement;
        if (isMaze)
        {
            movement = new Vector3(moveInput.x, moveInput.y, 0f) * moveSpeed * Time.deltaTime;
        }
        else
        {
            movement = new Vector3(moveInput.x, 0f, 0f) * moveSpeed * Time.deltaTime;

        }

        transform.position += movement;

        if (moveInput.x < 0)
        {
            mysprite.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            mysprite.flipX = false;
        }
    }

    private void HandleJump()
    {
        if (isMaze) return;

        bool jumpPressed = Keyboard.current[Key.W].wasPressedThisFrame || Keyboard.current[Key.UpArrow].wasPressedThisFrame;


        if (jumpPressed && jumpCount < maxJumps)
        {
            mybody.linearVelocity = new Vector2(mybody.linearVelocity.x, 0f); // Cancel upward/downward momentum
            mybody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            jumpCount++;
            isGrounded = false;
        }

        // Optional: Fast fall
        if ((Keyboard.current[Key.S].wasPressedThisFrame || Keyboard.current[Key.DownArrow].wasPressedThisFrame) && isGrounded)
        {
            mybody.AddForce(new Vector2(0f, -jumpforce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            jumpCount = 0; // Reset jump count on ground
        }
    }

    private void UpdateAnimationState()
{
        
        if (moveInput.x != 0)
        {
            // anim.SetBool("JUMP", false);
            anim.SetBool("WALK", true);
            // Vector3 scale = mytransform.localScale;
            // scale.x = 1f;
            // scale.y = 1f;
            // mytransform.localScale = scale;
        }
        else
        {
            // anim.SetBool("JUMP", false);
            anim.SetBool("WALK", false);
            // Vector3 scale = mytransform.localScale;
            // scale.x = 1f;
            // scale.y = 1f;
            // mytransform.localScale = scale;
        }
}
}
