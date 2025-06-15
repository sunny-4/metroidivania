using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 moveDirection;

    // This method should be called when the bullet is instantiated
    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized; // Normalize to ensure consistent speed
    }

    void Update()
    {
        // Move the bullet in the specified direction
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroy the bullet on collision
        if (!collision.gameObject.CompareTag("Player") )
        {
            if (!collision.gameObject.CompareTag("BossBullet"))
            {
                Destroy(gameObject);
            }
        }
    }
}