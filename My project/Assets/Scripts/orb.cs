using UnityEngine;

public class Orb : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (PlayerMovement.maxJumps == 2)
        {
            transform.position = new Vector3(150, 150, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement.maxJumps = 2;
            transform.position = new Vector3(150, 150, 0);
        }
    }
}
