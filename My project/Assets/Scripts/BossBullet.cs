
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 5f; // Speed of the bullet
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Flip the sprite if the bullet is moving left
        if (speed < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    void Update()
    {
        // Move the bullet
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the bullet on collision
        if (!collision.gameObject.CompareTag("PlayerBullet"))
        {
            Destroy(gameObject);
        }
     }

}