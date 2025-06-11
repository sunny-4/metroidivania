using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory.AddKey(keyID); // Call static method directly
            Destroy(gameObject);
        }
    }
}


