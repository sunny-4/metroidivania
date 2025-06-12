using UnityEngine.InputSystem;
using UnityEngine;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour
{
    public static HashSet<string> unlockedDoors = new HashSet<string>();
}

public class DoorUnlock : MonoBehaviour
{
    public string doorID;         // Unique ID for this door, set in Inspector
    public string keyID;          // Required key ID, set in Inspector
    public Vector3 hiddenPosition = new Vector3(9999, 9999, 0);

    private bool isPlayerNearby = false;
    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = transform.position;
        // If already unlocked, move door out of the scene
        if (GameStateManager.unlockedDoors.Contains(doorID))
        {
            transform.position = hiddenPosition;
        }
    }

    private void Update()
    {
        if (isPlayerNearby && Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (PlayerInventory.UseKey(keyID))
            {
                GameStateManager.unlockedDoors.Add(doorID);
                transform.position = hiddenPosition; // Move door out of the scene
                Debug.Log("Door unlocked and moved!");
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
