using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake()
    {
        // Prevent duplicate music players
        if (FindObjectsOfType<MusicPlayer>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
}
