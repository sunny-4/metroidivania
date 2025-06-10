
using UnityEngine;

public class Camerafollow : MonoBehaviour
{
    private Transform Player;// Start is called once before the first execution of Update after the MonoBehaviour is created
    private Transform temppos;

    private float minX = -55f;// Start is called once before the first execution of Update after the MonoBehaviour is created
    private float maxX = 54.8f;// Start is called once before the first execution of Update after the MonoBehaviour is created
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

        temppos = GameObject.FindWithTag("MainCamera").transform;
        temppos.position = new Vector3(Player.position.x, Player.position.y, -10f);

        transform.position = temppos.position;

    }
}