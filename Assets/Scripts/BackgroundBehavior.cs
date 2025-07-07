using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundBehavior : MonoBehaviour
{
    //Gameplay Numeric Variables
    [SerializeField] private float Speed;
    [SerializeField] private Vector3 Direction;
    //Gameobject Reference Variables
    [SerializeField] private GameObject Background;
    [SerializeField] private GameObject SpawnPoint;


    //Organisation Variables
    [SerializeField] private int BackgroundCounter;
    [SerializeField] private int SectionColour;
    private Sprite[] sprites;

    private void OnEnable()
    {
        Direction = new Vector3(1f, 0f, 0f);
        //SpawnPoint = .FindWithTag("BackgroundSpawn");
    }

    private void FixedUpdate()
    {
        Background.transform.position = Background.transform.position - Direction * Time.fixedDeltaTime;


    }

 

}
