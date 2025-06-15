
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed = 5f; // Speed of the bullet
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer
    public Sprite rightFacingSprite; // Sprite for right-facing direction
    public Sprite leftFacingSprite; // Sprite for left-facing direction

    void Start()
    {
        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Flip the sprite if the bullet is moving left
        spriteRenderer.sprite = speed > 0 ? leftFacingSprite : rightFacingSprite;
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