using UnityEngine;
using UnityEngine.SceneManagement;

public class playergameover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -7.47f)
            GameObject.Destroy(GameObject.FindFirstObjectByType<playergameover>());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            SceneManager.LoadScene("Game Over");
    }

}
