using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private float minX; 
    [SerializeField] private float maxX; 
    [SerializeField] private float velocity; 
    [SerializeField] private Transform mytransform; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {}

    // Update is called once per frame
    void Update()
    {
        mytransform.position += new Vector3(1f, 0f, 0f) * velocity * Time.deltaTime;

        if (mytransform.position.x < minX)
        {
            mytransform.position = new Vector3(minX, mytransform.position.y, mytransform.position.z);
            velocity *= -1;
        }
        else if (mytransform.position.x > maxX)
        {
            mytransform.position = new Vector3(maxX, mytransform.position.y, mytransform.position.z);
            velocity *= -1;
        }
    }
}
