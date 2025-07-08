using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool running;
    [SerializeField] private float runTime;
    public float RunTime
    {
        get
        {
            return runTime;
        }
    }
    [SerializeField] private int sectionNumber;
    public int SectionNumber
    {
        get
        {
        return sectionNumber;
        } 
     }

    void Awake()
    {
        running = true;
        sectionNumber = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (running)
        {
         runTime += Time.fixedDeltaTime;
        //Debug.Log(runTime);  
        if (runTime >= 15)
        {
            runTime = 0f;
            sectionNumber++;   
        }   
        }
        
    }
}
