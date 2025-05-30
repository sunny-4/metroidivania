using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomChanger : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneToLoad);
        }
    }
}

