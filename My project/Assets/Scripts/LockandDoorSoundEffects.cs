using UnityEngine;

public class LockandDoorSoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip KeyCollectSound;
    public AudioClip DoorUnlockSound;

    public void KeyCollect()
    {
        audioSource.PlayOneShot(KeyCollectSound);
    }

    public void DoorUnlock()
    {
        audioSource.PlayOneShot(DoorUnlockSound);
    }
}
