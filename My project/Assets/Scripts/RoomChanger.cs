using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomChanger : MonoBehaviour
{
    [SerializeField] private string SceneToLoad;
    [SerializeField] private float x_pos;
    [SerializeField] private float y_pos;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneToLoad);
            player.position = new Vector3(x_pos, y_pos, 0f);
        }
    }
}

