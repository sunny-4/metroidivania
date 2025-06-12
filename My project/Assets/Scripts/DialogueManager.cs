using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public Image characterIcon;
    public GameObject dialoguePanel;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI dialogueArea;

    private Queue<DialogueLine> lines;

    public bool isDialogueActive = false;

    public float typingSpeed = 0.2f;

    public Animator animator;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        dialoguePanel.SetActive(false);
        lines = new Queue<DialogueLine>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialoguePanel.SetActive(true);
        isDialogueActive = true;

        animator.Play("show");

        lines.Clear();

        foreach (DialogueLine dialogueLine in dialogue.dialogueLines)
        {
            lines.Enqueue(dialogueLine);
        }

        DisplayNextDialogueLine();
    }


    public void DisplayNextDialogueLine()
    {
        if (lines.Count == 0)
        {

            EndDialogue();
            return;
        }

        DialogueLine currentLine = lines.Dequeue();

        characterIcon.sprite = currentLine.character.icon;
        characterName.text = currentLine.character.name;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }

    IEnumerator TypeSentence(DialogueLine dialogueLine)
    {
        dialogueArea.text = "";
        foreach (char letter in dialogueLine.line.ToCharArray())
        {
            dialogueArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;

        animator.Play("hide");
    }

    void Update()
    {
        if (isDialogueActive && Keyboard.current[Key.Space].wasPressedThisFrame)
        {
            DisplayNextDialogueLine();
        }

        if (!isDialogueActive && Keyboard.current[Key.Space].wasPressedThisFrame)
        {
            dialoguePanel.SetActive(false);
        }

    }


}
 

