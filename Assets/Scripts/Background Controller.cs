using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BackgroundController : MonoBehaviour
{
    //Gameplay Numeric Variables
    [SerializeField] private float Speed;
    [SerializeField] private Vector3 Direction;
    [SerializeField] private float Background1X;
    [SerializeField] private float Background2X;
    private Color m_NewColor;



    //Organisation Variables
    [SerializeField] private int Background1Counter;
    [SerializeField] private int Background1Current
    ;
    [SerializeField] private int Background2Counter;
    [SerializeField] private int Background2Current;
    [SerializeField] private int SectionColour;
    [SerializeField] private Sprite[] sprites = new Sprite[2];
    private Color32[] colours = new Color32[3];
    [SerializeField] private GameObject Background1;
    [SerializeField] private GameObject Background2;

    //Gameobject Reference Variables
    [SerializeField] private GameObject SpawnPoint;
    [SerializeField] private GameManager gameManager;


    void Start()
    {
        Direction = new Vector3(1f, 0f, 0f);
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        Background1Current = 0;
        Background2Current = 1;

        colours[0] = new Color32(203, 140, 141, 255);
        colours[1] = new Color32(140, 180, 241, 255);
        colours[2] = new Color32(156, 231, 106, 255);

        Background1.GetComponent<SpriteRenderer>().color = colours[gameManager.SectionNumber];
        Debug.Log(colours[gameManager.SectionNumber]);
        Debug.Log(Background1.GetComponent<SpriteRenderer>().color);
        Background2.GetComponent<SpriteRenderer>().color = colours[gameManager.SectionNumber];



    }
    
    private void FixedUpdate()
    {
        

        if (gameManager.running == true)
        {
            Background1.transform.position = Background1.transform.position - Direction * Time.fixedDeltaTime * Speed;
            Background1X = Background1.transform.position.x;
            if (Background1X <= -22.75)
            {
                BackgroundChange(Background1, Background1Counter);
                Background1Counter = Random.Range(0, 2);
            }
            Background2.transform.position = Background2.transform.position - Direction * Time.fixedDeltaTime * Speed;
            Background2X = Background2.transform.position.x;
            if (Background2X <= -22.75)
            {
                BackgroundChange(Background2, Background2Counter);
                Background2Counter = Random.Range(0, 2);
            }
        }
        

    }

    private void BackgroundChange(GameObject Background, int BackgroundCounter)
    {
        Background.transform.position = SpawnPoint.transform.position;
        Background.GetComponent<SpriteRenderer>().sprite = sprites[BackgroundCounter];
        Background.GetComponent<SpriteRenderer>().color = colours[gameManager.SectionNumber]; 
       
    
    }
}
