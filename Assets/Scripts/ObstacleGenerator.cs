using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject HousePrefab1;
    public GameObject HousePrefab2;
    public GameObject HousePrefab3;
    public GameObject HousePrefab4;
    public GameObject HousePrefab5;
    public GameObject HousePrefab6;
    public GameObject HousePrefab7;
    public GameObject HousePrefab8;
    public GameObject HousePrefab9;
    public GameObject HousePrefab10;
    public GameObject HousePrefab11;
    public GameObject HousePrefab12;

    private float time;

    void Start()
    {
        time = 0;
        GenerateObstacle();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= 3)
        {
            time = 0;
            GenerateObstacle();
        }
    }

    void GenerateObstacle()
    {
        int random = Random.Range(1, 12);

        if (random == 1)
        {
            Instantiate(HousePrefab1, gameObject.transform);
        }

        if (random == 2)
        {
            Instantiate(HousePrefab2, gameObject.transform);
        }

        if (random == 3)
        {
            Instantiate(HousePrefab3, gameObject.transform);
        }

        if (random == 4)
        {
            Instantiate(HousePrefab4, gameObject.transform);
        }

        if (random == 5)
        {
            Instantiate(HousePrefab5, gameObject.transform);
        }

        if (random == 6)
        {
            Instantiate(HousePrefab6, gameObject.transform);
        }

        if (random == 7)
        {
            Instantiate(HousePrefab7, gameObject.transform);
        }

        if (random == 8)
        {
            Instantiate(HousePrefab8, gameObject.transform);
        }

        if (random == 9)
        {
            Instantiate(HousePrefab9, gameObject.transform);
        }

        if (random == 10)
        {
            Instantiate(HousePrefab10, gameObject.transform);
        }

        if (random == 11)
        {
            Instantiate(HousePrefab11, gameObject.transform);
        }

        if (random == 12)
        {
            Instantiate(HousePrefab12, gameObject.transform);
        }
    }
}