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
            SceneManager.LoadScene("Middle room 2");

        }
    }
}
