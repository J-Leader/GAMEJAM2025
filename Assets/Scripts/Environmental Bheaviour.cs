using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentalBheaviour : MonoBehaviour
{
    // Start is called before the first frame update
       private Vector3 direction;
    [SerializeField] private float movementSpeed;
     [SerializeField] private float scaleMin;
      [SerializeField] private float scaleMax;
      [SerializeField] private Vector3 localScale;
    public GameManager gameManager;
    void Awake()
    {

        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        direction = new Vector3(movementSpeed, 0f, 0f);
        movementSpeed = Random.Range(2f, 2f + gameManager.SectionNumber);
        localScale = new Vector3(Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax), Random.Range(scaleMin, scaleMax));
        transform.localScale = localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.running)
        {
            transform.position = transform.position - direction * Time.fixedDeltaTime * movementSpeed;
        }
    }
}

