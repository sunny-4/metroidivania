using UnityEngine;

public class PortalSoundEffects : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip portalsound;

    public void EnterPortal()
    {
        audioSource.PlayOneShot(portalsound);
    }

}
