using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ObstaclePrefab;

    [SerializeField] private float SpawnTimer;
    [SerializeField] private Vector3 SpawnPos;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float SpawnTimerMax;
    [SerializeField] private float SpawnTimerMin;



    void Start()
    {
        SpawnTimer = Random.Range(SpawnTimerMin, SpawnTimerMax);
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnTimer = SpawnTimer - Time.fixedDeltaTime;
        SpawnPos = new Vector3(transform.position.x, transform.position.y - Random.Range(0, 2f), transform.position.z);

        if (SpawnTimer <= 0)
        {
            Spawn();

        }
    }

    void Spawn()
    {
        Instantiate(ObstaclePrefab, SpawnPos, Quaternion.identity);
        SpawnTimer = Random.Range(SpawnTimerMin-gameManager.SectionNumber, SpawnTimerMax-gameManager.SectionNumber);  

     }
}
