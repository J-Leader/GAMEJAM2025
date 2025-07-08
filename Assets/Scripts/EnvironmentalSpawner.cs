using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] ObstaclePrefab = new GameObject[1];

    [SerializeField] private float SpawnTimer;
    [SerializeField] private Vector3 SpawnPos;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float SpawnTimerMax;
    [SerializeField] private float SpawnTimerMin;
    [SerializeField] private int SpawnPrefab;



    void Start()
    {
        SpawnTimer = Random.Range(SpawnTimerMin, SpawnTimerMax);
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.running)
        {
        SpawnTimer = SpawnTimer - Time.fixedDeltaTime;
        SpawnPos = new Vector3(transform.position.x, transform.position.y - Random.Range(0.5f, 2f), transform.position.z);
        SpawnPrefab = Random.Range(0, 1);
        if (SpawnTimer <= 0)
        {
            Spawn();

        }


    }
        
    }

    void Spawn()
    {
        Instantiate(ObstaclePrefab[SpawnPrefab], SpawnPos, Quaternion.identity);
        SpawnTimer = Random.Range(SpawnTimerMin-gameManager.SectionNumber, SpawnTimerMax-gameManager.SectionNumber);  

     }
}
