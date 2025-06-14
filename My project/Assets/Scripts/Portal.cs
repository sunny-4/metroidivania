using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] private int sequenceNumber;
    [SerializeField] private Transform _spawnPoint;
    private static int currentNumber = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.CompareTag("Player"))
        {
            if (sequenceNumber == currentNumber)
            {
                FindFirstObjectByType<PlayerMovement>().transform.position = _spawnPoint.position;
                currentNumber += 1;
                //Debug.Log("Keep going! Current = " + currentNumber);
            }
            else
            {
                if (sequenceNumber == 1)
                {
                    FindFirstObjectByType<PlayerMovement>().transform.position = _spawnPoint.position;
                    currentNumber = 2;
                }
                else
                {
                    FindFirstObjectByType<PlayerMovement>().transform.position = new Vector3(-12.98f, -11.11f, 0);
                    currentNumber = 1;
                }


                //Debug.Log("Oops! Current = " + currentNumber+", Sequence ="+ sequenceNumber);
            }
        GetComponent<PortalSoundEffects>().EnterPortal();
        }

    }
}