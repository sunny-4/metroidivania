using UnityEngine;

public class GravityZones : MonoBehaviour
{
    private GameObject playerObject;
    [SerializeField] private float gravityStrength = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float x = playerObject.transform.position.x;
        if ((x > -4.07 && x < 1.93) || (x > -37.09 && x < -12.99))
        {
            Physics2D.gravity = new Vector2(0, gravityStrength);
        }
        else
        {
            Physics2D.gravity = new Vector2(0, -1*gravityStrength);
        }
    }}