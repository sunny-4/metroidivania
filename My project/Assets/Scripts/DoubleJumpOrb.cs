using UnityEngine;

public class DoubleJumpOrb : MonoBehaviour
{
    private void Start()
    {
        // If already collected, destroy the orb immediately
        if (GameManager.HasDoubleJump)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.HasDoubleJump = true;
            Destroy(gameObject);
        }
    }
}
