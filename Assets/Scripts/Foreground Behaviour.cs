using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForegroundBehaviour : MonoBehaviour
{
       private Vector3 direction;
    [SerializeField] private float movementSpeed;
    public GameManager gameManager;

    private Color32[] colours = new Color32[5];

    void Awake()
    {

        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        direction = new Vector3(movementSpeed, 0f, 0f);
         colours[0] = new Color32(255, 255, 255, 255);
        colours[1] = new Color32(140, 180, 241, 255);
        colours[2] = new Color32(156, 231, 106, 255);
        colours[3] = new Color32(156, 231, 106, 255);
        colours[4] = colours[0];
        this.GetComponent<SpriteRenderer>().color = colours[gameManager.SectionNumber];
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
}
