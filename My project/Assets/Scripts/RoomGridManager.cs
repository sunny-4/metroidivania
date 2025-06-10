using UnityEngine;
using UnityEngine.UI;

public class RoomGridManager : MonoBehaviour
{
    public Image[] imageSlots;       // Assign the 4 grid images in inspector
    public Sprite[] sprites;         // Assign 5 sprites (0–4) in inspector
    public int conditionSlotIndex = 2; // Slot to be replaced (0–3)

    public PlayerInventory playerInventory;  // Assign this in inspector or find at runtime

    void Start()
    {
        // Initialize with first 4 sprites
        for (int i = 0; i < 4; i++)
        {
            imageSlots[i].sprite = sprites[i];
        }

        // Check condition
        if (playerInventory != null && playerInventory.HasKey("No idea"))
        {
            imageSlots[conditionSlotIndex].sprite = sprites[4];  // Replace with 5th sprite
        }
    }
}
