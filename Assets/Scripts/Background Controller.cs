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




    //Organisation Variables
    [SerializeField] private int BackgroundCounter;
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
        }
        Background2.transform.position = Background2.transform.position - Direction * Time.fixedDeltaTime;
        Background2X = Background2.transform.position.x;
        if (Background2X <= -20)
        {
            BackgroundChange(Background2);
        }

    }

    private void BackgroundChange(GameObject Background)
    {
        Background.transform.position = SpawnPoint.transform.position;

    }
}
