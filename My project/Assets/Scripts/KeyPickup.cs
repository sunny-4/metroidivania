using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyID;

    void Start()
    {
        if (PlayerInventory.HasKey(keyID))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<LockandDoorSoundEffects>().KeyCollect();
            PlayerInventory.AddKey(keyID);
            Destroy(gameObject);
        }
    }
}



