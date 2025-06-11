using UnityEngine;
using UnityEngine.UI;

public class RoomGridManager : MonoBehaviour
{
    public Image[] imageSlots;       // Assign the 4 grid images in inspector
    public Sprite[] sprites;         // Assign 5 sprites (0–4) in inspector
    public int conditionSlotIndex = 2; // Slot to be replaced (0–3)

    void Start()
    {
        // Initialize with first 4 sprites
        for (int i = 0; i < 4; i++)
        {
            imageSlots[i].sprite = sprites[i];
        }

        // Check condition using static call
        if (PlayerInventory.HasKey("No idea"))
        {
            imageSlots[conditionSlotIndex].sprite = sprites[4];  // Replace with 5th sprite
        }
    }
}
