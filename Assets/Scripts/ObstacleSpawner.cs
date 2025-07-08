using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject ObstaclePrefab;

    [SerializeField] private float SpawnTimer;
    [SerializeField] private GameManager gameManager;



    void Start()
    {
        SpawnTimer = Random.Range(7f, 13f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnTimer = SpawnTimer - Time.fixedDeltaTime;

        if (SpawnTimer <= 0)
        {
            Spawn();

        }
    }

    void Spawn()
    {
        Instantiate(ObstaclePrefab, transform.position, Quaternion.identity);
        SpawnTimer = Random.Range(7f-gameManager.SectionNumber, 13f-gameManager.SectionNumber);  

     }
}
