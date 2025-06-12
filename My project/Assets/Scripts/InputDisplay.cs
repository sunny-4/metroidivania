using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class InputDisplay : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text displayText;
    public bool repair = false;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
             SceneManager.LoadScene("O2 room");
        }
    }
    public void DisplayInput()
    {
        if (inputField.text == "ujxr")
        {
            displayText.text = "The password is correct. The O2 machine is functional again";
            repair = true;
        }
        else
        {
            displayText.text = inputField.text + "is the wrong password.";
        }
    }
}
