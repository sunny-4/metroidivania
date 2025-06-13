using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class cameraroomtomiddleroom : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current[Key.B].wasPressedThisFrame)
        {
            SceneTransitionManager.comingFromScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("Middle room 2");

        }
    }
}
