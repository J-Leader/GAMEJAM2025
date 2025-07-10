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
    private int scriptedSectionTracker;



    void Start()
    {
        SpawnTimer = Random.Range(SpawnTimerMin, SpawnTimerMax);
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        scriptedSectionTracker = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        /*
        Goal: Expand this code to have different spawn behaviours each section
        Required scripts:
        - Object (speed)
        - GameMnagaer (track sections)
        - This (rate of spawning, scripted sections A and B)

        Section A:
        - one trash can at base speed
        Section 1: 
        - increased trash can frequency: decrease min/max
        Section 2: 
        - increased trash can speed: increase speed by accessing gameobject
        Section 3:     
        - increase both frequency and speed: decrease min/max and increase speed
        Section 4:
        - down to one trash can at base speed
        */
        if (gameManager.running)
        {
            SpawnTimer = SpawnTimer - Time.fixedDeltaTime;


            if (SpawnTimer <= 0)
            {
                //Spawn();
                spawningPatterns();

            }
        }



    }

    void Spawn()
    {
        Instantiate(ObstaclePrefab, transform.position, Quaternion.identity);
        SpawnTimer = Random.Range(SpawnTimerMin - gameManager.SectionNumber, SpawnTimerMax - gameManager.SectionNumber);

    }

    void scriptedSpawn() 
    {
        Instantiate(ObstaclePrefab, transform.position, Quaternion.identity);
    }

    void spawningPatterns() // changes object behaviour based on section 
    {
        if (gameManager.GetComponent<GameManager>().SectionNumber == 0 && scriptedSectionTracker == 0)
        {
            Spawn();
            scriptedSectionTracker++;
        }
        else if (gameManager.GetComponent<GameManager>().SectionNumber == 1)
        {
            if (scriptedSectionTracker == 1)
            {
                SpawnTimerMax = SpawnTimerMax - 2;
                SpawnTimerMin = SpawnTimerMin - 2;
                scriptedSectionTracker++;
            }
            Spawn();
        }
        else if (gameManager.GetComponent<GameManager>().SectionNumber == 2)
        {
            if (scriptedSectionTracker == 2)
            {
                SpawnTimerMax = SpawnTimerMax - 1;
                SpawnTimerMin = SpawnTimerMin - 1;
                scriptedSectionTracker++;
            }
            Spawn();
        }
        else if (gameManager.GetComponent<GameManager>().SectionNumber == 3)
        {
            if (scriptedSectionTracker == 3)
            {
                SpawnTimerMax = SpawnTimerMax - 0.5f;
                SpawnTimerMin = SpawnTimerMin - 0.5f;
                scriptedSectionTracker++;
            }
            Spawn();
        }
        else
        {
            
        }
    }
}
