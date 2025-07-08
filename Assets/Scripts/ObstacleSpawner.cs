using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{

    [SerializeField] private GameObject ObstaclePrefab;

    [SerializeField] private float SpawnTimer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float SpawnTimerMax;
    [SerializeField] private float SpawnTimerMin;



    void Start()
    {
        SpawnTimer = Random.Range(SpawnTimerMin, SpawnTimerMax);

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
        SpawnTimer = Random.Range(SpawnTimerMin-gameManager.SectionNumber, SpawnTimerMax-gameManager.SectionNumber);  

     }
}
