using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyID;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddKey(keyID);
                Destroy(gameObject);
            }
        }
    }
}


