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
    [SerializeField] private int Background2Counter;
    [SerializeField] private int SectionColour;
    private Sprite[] sprites;
    [SerializeField] private GameObject Background1;
    [SerializeField] private GameObject Background2;

    //Gameobject Reference Variables
    [SerializeField] private GameObject SpawnPoint;
  

    void Start()
    {
        Direction = new Vector3(1f, 0f, 0f);
    }
    
    private void FixedUpdate()
    {
        Background1.transform.position = Background1.transform.position - Direction * Time.fixedDeltaTime;
        Background1X = Background1.transform.position.x;
        if (Background1X <= -20) 
        {
            BackgroundChange(Background1);
            Background1Counter = Background1Counter + 2;
        }
        Background2.transform.position = Background2.transform.position - Direction * Time.fixedDeltaTime;
        Background2X = Background2.transform.position.x;
        if (Background2X <= -20)
        {
            BackgroundChange(Background2);
            Background2Counter = Background2Counter + 2;
        }

    }
    private void Update()
    {
        //Background1.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0f);
    }

    private void BackgroundChange(GameObject Background)
    {
        Background.transform.position = SpawnPoint.transform.position;
        Background.GetComponent<SpriteRenderer>().color = new Color(0f, 255f, 0f); 
        Debug.Log(Background.GetComponent<SpriteRenderer>().color);
        


    }
}
