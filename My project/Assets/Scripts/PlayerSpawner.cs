using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    private GameObject playerObject;


    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
        string fromScene = SceneTransitionManager.comingFromScene;

        if (fromScene == "Introduction")
        {
            playerObject.transform.position = new Vector3(-3, -2.5f, 0); // Example position
        }
        else if (fromScene == "O2 game")
        {
            playerObject.transform.position = new Vector3(52, -7, 0);
        }
        else if (fromScene == "Camera room")
        {
            playerObject.transform.position = new Vector3(37, 3, 0);
        }

    }
}