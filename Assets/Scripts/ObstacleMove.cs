using Unity.VisualScripting;
using UnityEngine;

public class ObstacleMove : MonoBehaviour
{
    //speed changes global variable/ multiplier?
    void Start()
    {
        
    }

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z+0.05f);

        if(gameObject.transform.position.z > 50)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
