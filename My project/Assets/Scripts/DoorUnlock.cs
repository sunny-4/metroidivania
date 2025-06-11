using UnityEngine.InputSystem;
using UnityEngine;

public class DoorUnlock : MonoBehaviour
{
    public GameObject door;      // Assign your door GameObject in the Inspector
    public string keyID;         // Set the required key ID in the Inspector

    private bool isPlayerNearby = false;

    private void Update()
    {
        if (isPlayerNearby && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (PlayerInventory.UseKey(keyID))
            {
                gameObject.SetActive(false); // Hide or "open" the door
                Debug.Log("Door unlocked!");
            }
            else
            {
                Debug.Log("You need the correct key!");
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}
