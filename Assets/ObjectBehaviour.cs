using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    private Vector3 direction;
    public float movementSpeed;
    public GameManager gameManager;
    void Awake()
    {
        direction = new Vector3(movementSpeed, 0f, 0f);
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        movementSpeed = Random.Range(2f, 2f+gameManager.SectionNumber);
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
