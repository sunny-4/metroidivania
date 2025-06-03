using UnityEngine;

public class Movetile1 : MonoBehaviour
{
    public float minY;
    public float maxY;
    public float velocity;
    private Transform mytransform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        minY = 0.23f;
        maxY = 7.27f;
        velocity = 5f;
        mytransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        print(velocity);
        mytransform.position += new Vector3(0f, 1f, 0f) * velocity * Time.deltaTime;

        if (mytransform.position.y < minY)
        {
            mytransform.position = new Vector3(mytransform.position.x, minY, mytransform.position.z);
            velocity *= -1;
        }
        else if (mytransform.position.y > maxY)
        {
            mytransform.position = new Vector3(mytransform.position.x, maxY, mytransform.position.z);
            velocity *= -1;
        }
    }
}


