using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CameraScenechanger : MonoBehaviour
{

    private GameObject playerObject;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if ((playerObject.transform.position.x < 42) && (playerObject.transform.position.x > 32) && Keyboard.current[Key.E].wasPressedThisFrame)
        {
            SceneManager.LoadScene("Camera room");
        }
    }
}
