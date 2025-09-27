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

    public GameObject Chonk;
    public CatControl CatControl;

    private float time;
    private readonly int interval = 3;

    void Start()
    {
        CatControl = Chonk.GetComponent<CatControl>();

        time = 0;
        GenerateObstacle();
    }

    void Update()
    {
        time += Time.deltaTime;

        if (time >= interval)
        {
            time = 0;
            GenerateObstacle();
        }
    }

    void GenerateObstacle()
    {
        int random = Random.Range(1, 12);
        GameObject house;

        if (random == 1)
        {
            house = Instantiate(HousePrefab1, gameObject.transform);
            
        }
        else if (random == 2)
        {
            house = Instantiate(HousePrefab2, gameObject.transform);
        }
        else if (random == 3)
        {
            house = Instantiate(HousePrefab3, gameObject.transform);
        }
        else if (random == 4)
        {
            house = Instantiate(HousePrefab4, gameObject.transform);
        }
        else if (random == 5)
        {
            house = Instantiate(HousePrefab5, gameObject.transform);
        }
        else if (random == 6)
        {
            house = Instantiate(HousePrefab6, gameObject.transform);
        }
        else if (random == 7)
        {
            house = Instantiate(HousePrefab7, gameObject.transform);
        }
        else if (random == 8)
        {
            house = Instantiate(HousePrefab8, gameObject.transform);
        }
        else if (random == 9)
        {
            house = Instantiate(HousePrefab9, gameObject.transform);
        }
        else if (random == 10)
        {
            house = Instantiate(HousePrefab10, gameObject.transform);
        }
        else if (random == 11)
        {
            house = Instantiate(HousePrefab11, gameObject.transform);
        }
        else
        {
            house = Instantiate(HousePrefab12, gameObject.transform);
        }

        house.gameObject.GetComponent<ObstacleMove>().Speed = CatControl.CurrentSpeed;
    }
}