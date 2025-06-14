using UnityEngine;

public class PlayerSoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip gunshotClip;
    public AudioClip hurtClip;

    public void PlayGunshot()
    {
        audioSource.PlayOneShot(gunshotClip);
    }

    public void PlayHurt()
    {
        audioSource.PlayOneShot(hurtClip);
    }
}
