using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    private Transform player;

    [SerializeField] private float minX = -100.0f;
    [SerializeField] private float maxX = 100.0f;
    [SerializeField] private float minY = -100.0f;
    [SerializeField] private float maxY = 100.0f;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
    }

    void LateUpdate()
    {
        if (!player) return;

        Vector3 camPos = new Vector3(player.position.x, player.position.y, -10f);
        camPos.x = Mathf.Clamp(camPos.x, minX, maxX);
        camPos.y = Mathf.Clamp(camPos.y, minY, maxY);

        transform.position = camPos; // Don't re-fetch camera each frame
    }
}
