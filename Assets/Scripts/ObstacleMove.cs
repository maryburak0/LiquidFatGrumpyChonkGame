using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        if(Speed == 0)
        {
            Speed = 0.05f;
        }
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+(Speed));

        if(gameObject.transform.position.z > 50)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
