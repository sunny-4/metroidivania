
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // Required for UI components

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar; // Reference to the health bar UI

    void Start()
    {
        currentHealth = maxHealth;

        // Initialize the health bar value
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player Health: " + currentHealth);

        // Update the health bar UI
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        SceneManager.LoadScene("Game Over");
        // Add game-over logic or respawn functionality here
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BossBullet"))
        {
            // Assuming enemy bullets deal 20 damage
            TakeDamage(20);
        }
    }
}