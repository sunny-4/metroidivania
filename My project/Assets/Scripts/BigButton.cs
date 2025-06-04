using UnityEngine;

public class BigButton : MonoBehaviour
{
    public int jumpsNeeded = 5;
    public float pressDepth = 0.1f;
    public static bool finaleStart = false;

    private int jumpCount = 0;
    private bool playerWasOnButton = false;
    private Rigidbody2D playerRb;
    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
        }
    }
    private void Update()
    {
        if(playerRb.linearVelocity.y > 0)
        {
            playerWasOnButton = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        if (!playerWasOnButton) // Only allow press if player was previously off
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y < 0.5f) // Hit from above
                {
                    //Debug.Log("Player landed on button!");
                    RegisterJump();
                    break;
                }
            }
        }
    }

    



    void RegisterJump()
    {
        if (jumpCount > jumpsNeeded) return;
        if (jumpCount == jumpsNeeded)
        {
            transform.position = new Vector3(13.92f, -4.97f, 0);
            return;
        }
        jumpCount++;
        transform.position -= new Vector3(0, pressDepth, 0);
        //Debug.Log($"Jump {jumpCount} registered");
        playerWasOnButton = true;

        if (jumpCount >= jumpsNeeded)
        {
            //Debug.Log("Button fully pressed. Starting finale!");
            finaleStart = true;
        }
    }
}
