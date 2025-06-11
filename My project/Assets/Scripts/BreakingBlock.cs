using System.Collections.Generic;
using UnityEngine;

public class BreakingBlock: MonoBehaviour
{
    public string blockID; // Set this uniquely for each block in Inspector

    public int jumpsNeeded = 3;
    public Sprite[] sprites;
    private int jumpCount = 0;
    private bool playerWasOnButton = false;
    private Rigidbody2D playerRb;
    private Queue<float> recentYVelocities = new Queue<float>();
    public int velocitySampleFrames = 5;


    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            playerRb = player.GetComponent<Rigidbody2D>();
        }

        // Check if block was broken earlier
        if (PlayerPrefs.GetInt("BlockBroken_" + blockID, 0) == 1)
        {
            transform.position = new Vector3(150f, -4.97f, 0); // Or disable if preferred
        }
    }

    private void Update()
    {
        if (playerRb != null)
        {
            float vy = playerRb.linearVelocity.y;

            if (recentYVelocities.Count >= velocitySampleFrames)
                recentYVelocities.Dequeue();

            recentYVelocities.Enqueue(vy);

            // Reset flag when jumping up
            if (vy > 0.1f)
            {
                playerWasOnButton = false;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
            return;

        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y < -0.5f) // Landed from above
            {
                if (!playerWasOnButton && WasFallingRecently())
                {
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
            transform.position = new Vector3(150f, -4.97f, 0);
            PlayerPrefs.SetInt("BlockBroken_" + blockID, 1); // Save broken state
            PlayerPrefs.Save(); // Force save
            return;
        }

        GetComponent<SpriteRenderer>().sprite = sprites[jumpCount];
        jumpCount++;
        playerWasOnButton = true;
    }


    private bool WasFallingRecently()
    {
        foreach (float vy in recentYVelocities)
        {
            if (vy < -1f) // Was falling at any point
                return true;
        }
        return false;
    }

}