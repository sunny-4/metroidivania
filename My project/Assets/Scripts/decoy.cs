using TMPro;
using UnityEngine;

public class Decoy : MonoBehaviour
{
    public static bool decoyTrigger = false;
    private TMP_Text decoyText;
    private void Start()
    {
        GameObject decoyObject = GameObject.FindWithTag("Decoy");
        if (decoyObject != null)
        {
            decoyText = decoyObject.GetComponent<TMP_Text>();
        }
    }

    private void Update()
    {
        if (decoyTrigger)
            decoyText.rectTransform.localPosition = new Vector3(-432.82f, -203.96f, 0);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            decoyTrigger = true;
            Debug.Log("Triggered!");
        }
    }
}
