using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UIElements;


public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 moveInput;
    private SpriteRenderer mysprite;
    // private Animator anim;
    // private string ANIM = "Walk";
    private Rigidbody2D mybody;
    private float jumpforce = 10f;
    private bool isGrounded = false;
    // private string ANIMA = "Jump";
    [SerializeField] private bool isMaze = false;

    public void OnMove(InputValue value) // <-- Correct signature for Send Messages
    {
        moveInput = value.Get<Vector2>();
    }


    void Start()
    {
        mysprite = GetComponent<SpriteRenderer>();
        // anim = GetComponent<Animator>();
        mybody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Move();
        Jump();
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

    private void Jump()
    {
        if ((Keyboard.current[Key.W].isPressed || Keyboard.current[Key.UpArrow].isPressed) && isGrounded)
            if ((Keyboard.current[Key.W].isPressed || Keyboard.current[Key.UpArrow].isPressed) && isGrounded && !(isMaze))
            {
                isGrounded = false;
                mybody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            }
        if ((Keyboard.current[Key.S].isPressed || Keyboard.current[Key.DownArrow].isPressed) && isGrounded && !(isMaze))
        {
            isGrounded = false;
            mybody.AddForce(new Vector2(0f, -1 * jumpforce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
