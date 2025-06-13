using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Roomchangerintro : MonoBehaviour
{
    [SerializeField] private bool alpha;
    private GameObject playerObject;
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (alpha)
        {
            if (Keyboard.current[Key.B].wasPressedThisFrame)
            {
                SceneTransitionManager.comingFromScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene("Store Room");
            }
        }

        else
        {
            if ((playerObject.transform.position.x < -1) && (playerObject.transform.position.x > -6) && Keyboard.current[Key.E].wasPressedThisFrame)
            {
                SceneManager.LoadScene("Introduction");
            }
        }
    }
}
