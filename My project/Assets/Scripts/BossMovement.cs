using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public Transform pointA; // First point
    public Transform pointB; // Second point
    public float dashSpeed = 10f; // Speed of the dash
    public float detectionRadius = 3f; // Radius to detect the player
    public Transform player; // Reference to the player
    public GameObject bulletPrefab; // Prefab for the boss's bullet
    public Transform firePointRight; // Firing point for right direction
    public Transform firePointLeft; // Firing point for left direction
    public float fireRate = 1f; // Time between shots
    public Sprite rightFacingSprite; // Sprite for right-facing direction
    public Sprite leftFacingSprite; // Sprite for left-facing direction
    public float health = 100f; // Boss's health

    private Transform currentPoint; // The point the boss is currently at
    private bool isDashing = false; // Whether the boss is currently dashing
    private bool isFacingRight = false; // Whether the boss is facing right
    private float nextActionTime = 0f; // Time for the next action
    private Transform activeFirePoint; // The currently active firing point
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer

    void Start()
    {
        // Start at Point A
        currentPoint = pointA;
        transform.position = currentPoint.position;

        // Set the initial active firing point
        activeFirePoint = firePointLeft;

        // Get the SpriteRenderer component
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on the boss object!");
        }

        // Set the initial sprite
        UpdateSprite();
    }

    void Update()
    {
        if (!isDashing && Time.time >= nextActionTime)
        {
            CheckPlayerProximity();
            PerformActionBasedOnHealth();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Boss took damage: " + damage + ", Current Health: " + health);
        if (health <= 0)
        {
            Debug.Log("Boss defeated!");
            Die();
        }
    }

    void Die()
    {
        // Handle boss death (e.g., destroy the boss, trigger an event, etc.)
        Destroy(gameObject);
    }

    void PerformActionBasedOnHealth()
    {
        if (health > 80)
        {
            ShootSingle(); // Shoot a single bullet
            nextActionTime = Time.time + 1f; // 1-second interval
        }
        else if (health > 60)
        {
            StartCoroutine(ShootBurst(3, 0.2f)); // Burst of 3 bullets with 0.2s between each
            nextActionTime = Time.time + 1.5f; // 1-second interval
        }
        else if (health > 40)
        {
            StartCoroutine(ShootContinuous(2f)); // Shoot continuously for 2 seconds
            nextActionTime = Time.time + 3f; // 2 seconds of shooting + 1-second interval
        }
        else if (health > 20)
        {
            StartCoroutine(DashAndShoot(3f)); // Dash, then shoot for 3 seconds
            nextActionTime = Time.time + 4f; // Dash + shooting duration
        }
        else
        {
            StartCoroutine(DashMultipleAndShoot(5, 4f)); // Dash 5 times, then shoot for 4 seconds
            nextActionTime = Time.time + 6.5f; // Dashing + shooting duration
        }
    }

    void ShootSingle()
    {
        // Instantiate(bulletPrefab, activeFirePoint.position, Quaternion.identity);
        // Instantiate a bullet at the active firing point
        GameObject bullet = Instantiate(bulletPrefab, activeFirePoint.position, Quaternion.identity);
        BossBullet bossBullet = bullet.GetComponent<BossBullet>();

        // Set the bullet's speed based on the boss's facing direction
        if (!isFacingRight)
        {
            bossBullet.speed = -Mathf.Abs(bossBullet.speed); // Shoot left
        }
        else
        {
            bossBullet.speed = Mathf.Abs(bossBullet.speed); // Shoot right
        }

        // Set the next fire time
        // nextFireTime = Time.time + fireRate;
    }


    System.Collections.IEnumerator ShootBurst(int count, float interval)
    {
        for (int i = 0; i < count; i++)
        {
            ShootSingle();
            yield return new WaitForSeconds(interval);
        }
    }

    System.Collections.IEnumerator ShootContinuous(float duration)
    {
        float endTime = Time.time + duration;
        while (Time.time < endTime)
        {
            ShootSingle();
            yield return new WaitForSeconds(0.1f); // Fire every 0.1 seconds
        }
    }

    System.Collections.IEnumerator DashAndShoot(float shootDuration)
    {
        yield return DashToOtherPoint(); // Perform a dash
        yield return ShootContinuous(shootDuration); // Shoot for the specified duration
    }

    System.Collections.IEnumerator DashMultipleAndShoot(int dashCount, float shootDuration)
    {
        for (int i = 0; i < dashCount; i++)
        {
            yield return DashToOtherPoint(); // Perform a dash
        }
        yield return ShootContinuous(shootDuration); // Shoot for the specified duration
    }

    void CheckPlayerProximity()
    {
        // Check if the player is within the detection radius of the current point
        if (Vector2.Distance(player.position, currentPoint.position) <= detectionRadius)
        {
            StartCoroutine(DashToOtherPoint());
        }
    }

    System.Collections.IEnumerator DashToOtherPoint()
    {
        isDashing = true;

        // Set the other point as the target
        Transform targetPoint = currentPoint == pointA ? pointB : pointA;

        // Dash towards the target point
        while (Vector2.Distance(transform.position, targetPoint.position) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, dashSpeed * Time.deltaTime);
            yield return null;
        }

        // Snap to the target point and update the current point
        transform.position = targetPoint.position;
        currentPoint = targetPoint;

        // Switch the firing point and update the sprite
        SwitchFiringPoint();
        UpdateSprite();

        isDashing = false;
    }

    void SwitchFiringPoint()
    {
        // Switch the active firing point based on the direction
        isFacingRight = !isFacingRight;
        activeFirePoint = isFacingRight ? firePointRight : firePointLeft;
    }

    void UpdateSprite()
    {
        // Update the sprite based on the facing direction
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = isFacingRight ? rightFacingSprite : leftFacingSprite;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("PlayerBullet"))
            {
                TakeDamage(5);
            }
        }

}



// using UnityEngine;

// public class BossMovement : MonoBehaviour
// {
//     public Transform pointA; // First point
//     public Transform pointB; // Second point
//     public float dashSpeed = 10f; // Speed of the dash
//     public float detectionRadius = 3f; // Radius to detect the player
//     public Transform player; // Reference to the player
//     public GameObject bulletPrefab; // Prefab for the boss's bullet
//     public Transform firePointRight; // Firing point for right direction
//     public Transform firePointLeft; // Firing point for left direction
//     public float fireRate = 1f; // Time between shots
//     public Sprite rightFacingSprite; // Sprite for right-facing direction
//     public Sprite leftFacingSprite; // Sprite for left-facing direction

//     private Transform currentPoint; // The point the boss is currently at
//     private bool isDashing = false; // Whether the boss is currently dashing
//     private bool isFacingRight = false; // Whether the boss is facing right
//     private float nextFireTime = 0f; // Time when the boss can fire next
//     private Transform activeFirePoint; // The currently active firing point
//     private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer

//     void Start()
//     {
//         // Start at Point A
//         currentPoint = pointA;
//         transform.position = currentPoint.position;

//         // Set the initial active firing point
//         activeFirePoint = firePointLeft;

//         // Get the SpriteRenderer component
//         spriteRenderer = GetComponent<SpriteRenderer>();
//         if (spriteRenderer == null)
//         {
//             Debug.LogError("SpriteRenderer not found on the boss object!");
//         }

//         // Set the initial sprite
//         UpdateSprite();
//     }

//     void Update()
//     {
//         if (!isDashing)
//         {
//             CheckPlayerProximity();
//             Shoot();
//         }
//     }

//     void CheckPlayerProximity()
//     {
//         // Check if the player is within the detection radius of the current point
//         if (Vector2.Distance(player.position, currentPoint.position) <= detectionRadius)
//         {
//             StartCoroutine(DashToOtherPoint());
//         }
//     }

//     System.Collections.IEnumerator DashToOtherPoint()
//     {
//         isDashing = true;

//         // Set the other point as the target
//         Transform targetPoint = currentPoint == pointA ? pointB : pointA;

//         // Dash towards the target point
//         while (Vector2.Distance(transform.position, targetPoint.position) > 0.1f)
//         {
//             transform.position = Vector2.MoveTowards(transform.position, targetPoint.position, dashSpeed * Time.deltaTime);
//             yield return null;
//         }

//         // Snap to the target point and update the current point
//         transform.position = targetPoint.position;
//         currentPoint = targetPoint;

//         // Switch the firing point and update the sprite
//         SwitchFiringPoint();
//         UpdateSprite();

//         isDashing = false;
//     }

//     void SwitchFiringPoint()
//     {
//         // Switch the active firing point based on the direction
//         isFacingRight = !isFacingRight;
//         activeFirePoint = isFacingRight ? firePointRight : firePointLeft;
//     }

//     void UpdateSprite()
//     {
//         // Update the sprite based on the facing direction
//         if (spriteRenderer != null)
//         {
//             spriteRenderer.sprite = isFacingRight ? rightFacingSprite : leftFacingSprite;
//         }
//     }

//     void Shoot()
//     {
//         // Check if it's time to fire
//         if (Time.time >= nextFireTime)
//         {
//             // Instantiate a bullet at the active firing point
//             GameObject bullet = Instantiate(bulletPrefab, activeFirePoint.position, Quaternion.identity);
//             BossBullet bossBullet = bullet.GetComponent<BossBullet>();

//             // Set the bullet's speed based on the boss's facing direction
//             if (!isFacingRight)
//             {
//                 bossBullet.speed = -Mathf.Abs(bossBullet.speed); // Shoot left
//             }
//             else
//             {
//                 bossBullet.speed = Mathf.Abs(bossBullet.speed); // Shoot right
//             }

//             // Set the next fire time
//             nextFireTime = Time.time + fireRate;
//         }
//     }
// }
