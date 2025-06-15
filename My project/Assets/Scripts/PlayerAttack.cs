
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform GunPointRight; // Fire point for shooting to the right
    public Transform GunPointLeft;  // Fire point for shooting to the left
    public float fireRate = 0.5f;    // Time in seconds between shots
    private float nextFireTime = 0f; // Tracks when the player can shoot next
    private Vector2 lastInputDirection = Vector2.right; // Default to facing right

    void Update()
    {
        // Update the last input direction based on player input
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            lastInputDirection = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            lastInputDirection = Vector2.right;
        }

        // Shoot when the fire button is pressed and the cooldown has elapsed
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime) // Replace with Input System equivalent if needed
        {
            Shoot();
            nextFireTime = Time.time + fireRate; // Set the next allowed fire time
        }
    }

    void Shoot()
    {
        Transform selectedFirePoint = lastInputDirection == Vector2.right ? GunPointRight : GunPointLeft;

        // Instantiate the bullet at the selected fire point
        GameObject bullet = Instantiate(bulletPrefab, selectedFirePoint.position, Quaternion.identity);

        // Set the bullet's direction based on the last input direction
        bullet.GetComponent<PlayerBullet>().SetDirection(lastInputDirection);
    }
}