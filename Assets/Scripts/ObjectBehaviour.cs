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

        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        direction = new Vector3(movementSpeed, 0f, 0f);
        movementSpeed = Random.Range(2f + (gameManager.SectionNumber - 1), 2f + gameManager.SectionNumber);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.running)
        {
            transform.position = transform.position - direction * Time.fixedDeltaTime * movementSpeed;
        }
        if(transform.position.x <= -20)
        {
            Destroy(gameObject);
        }
    }
    
    void OnTriggerExit2D(Collider2D other) // stops the game if the player has hit a trash can
    {
        if (other.IsTouchingLayers(6) == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }
}
