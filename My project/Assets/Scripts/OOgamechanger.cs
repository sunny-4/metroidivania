using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
public class OOgamechanger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private GameObject playerObject;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if ((playerObject.transform.position.x < 56) && (playerObject.transform.position.x > 49) && Keyboard.current[Key.E].wasPressedThisFrame)
        {
            SceneManager.LoadScene("O2 game");
        }
    }
}
