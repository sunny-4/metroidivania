using UnityEngine;

public class Thinblockmovement : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float velocity;
    private Transform mytransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minY = -4.75f;
        maxY = -0.75f;
        velocity = 5f;
        mytransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        mytransform.position += new Vector3(0f, 1f, 0f) * velocity * Time.deltaTime;

        if (mytransform.position.y < minY)
        {
            velocity *= -1;
        }
        else if (mytransform.position.y > maxY)
        {
            velocity *= -1;
        }
    }
}
