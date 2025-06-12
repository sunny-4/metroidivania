using UnityEngine;
using UnityEngine.SceneManagement;
public class RoomChanger : MonoBehaviour
{
    [SerializeField] private LevelConnection _connection;
    [SerializeField] private string SceneToLoad;
    [SerializeField] private Transform _spawnPoint;


    private void Start()
    {
        if(_connection == LevelConnection._activeConnection)
        {
            FindFirstObjectByType<PlayerMovement>().transform.position = _spawnPoint.position;
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
       
        if (collider.CompareTag("Player"))
        {
            LevelConnection._activeConnection = _connection;
            SceneManager.LoadScene(SceneToLoad);

        }
    }
}

