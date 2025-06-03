using UnityEngine;

public class vertmotionprison : MonoBehaviour
{
    [SerializeField] private float minY; 
    [SerializeField] private float maxY; 
    [SerializeField] private float velocity; 
    [SerializeField] private Transform mytransform; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {

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
