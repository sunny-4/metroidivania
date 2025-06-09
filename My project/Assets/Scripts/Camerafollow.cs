
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    private Transform Player;// Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform temppos;

    [SerializeField] private float minX = -100.0f;// Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private float maxX = 100.0f;
    [SerializeField] private float minY = -100.0f;
    [SerializeField] private float maxY = 100.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!Player)
        {
            return;
        }
        Transform temppos = GameObject.FindWithTag("MainCamera").transform;
        Vector3 camPos = new Vector3(Player.position.x, Player.position.y, -10f);

        // Clamp the camera position
        camPos.x = Mathf.Clamp(camPos.x, minX, maxX);
        camPos.y = Mathf.Clamp(camPos.y, minY, maxY);

        // Apply the clamped position to the camera
        temppos.position = camPos;


    }
}