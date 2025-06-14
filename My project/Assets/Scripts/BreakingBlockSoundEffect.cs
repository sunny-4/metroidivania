using UnityEngine;

public class BreakingBlockSoundEffect : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip breaksound;

    public void BlockBreakSound()
    {
        audioSource.PlayOneShot(breaksound);
    }
}
