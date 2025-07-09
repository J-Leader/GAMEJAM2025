using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public bool gameStart;
    public bool running;
    [SerializeField] private float runTime;

    // Audio
    public AudioClip[] musicClips = new AudioClip[6]; // holds audio clips for sections
    public AudioSource music; // the audio source for our section music
    public AudioSource bell; // the audio source for the bell
    public AudioClip sectionA; 
    public AudioClip section1;
    public AudioClip section2;
    public AudioClip section3;
    public AudioClip sectionB;
    public AudioClip ambience; // menu
    private bool hasPlayed = false; // checks whether the bell has played yet
    private bool sectionChange = false; // checks whether we've changed sections

    public GameObject player;

    public float RunTime
    {
        get
        {
            return runTime;
        }
    }
    [SerializeField] private int lastSection;
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
        running = false;
        gameStart = false;
        sectionNumber = 0;
        lastSection = SectionNumber; // set our last section to the section number (will be 0 at the beginning of the game)

        // fill in the array - these values need to have an AudioClip assigned in the editor
        musicClips[0] = sectionA;
        musicClips[1] = section1;
        musicClips[2] = section2;
        musicClips[3] = section3;
        musicClips[4] = sectionB;
        musicClips[5] = ambience;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStart == true)
        {
            running = true;
        }
        else
        {
            running = false;
        }

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
        else
        {
            
        }


        musicManager(); // stops the music if we hit a trash can
        if (running == true) // change the section music while running
        {
            sectionMusic();
        }
    }

    private void sectionMusic() // changes the section music based on the section number
    {
        sectionAudioChange(); // manages the sectionChnage switch
        if (SectionNumber == 1 && sectionChange == true) // section 1
        {
            music.clip = musicClips[1]; // set the clip to the section clip
            music.Play(); // play music
            sectionChange = false; // set section change to false until we get to new section
        }
        else if (SectionNumber == 2 && sectionChange == true) // section 2
        {
            {
                music.clip = musicClips[2];
                music.Play();
                sectionChange = false;
            }
        }
        else if (SectionNumber == 3 && sectionChange == true) // section 3
        {
            music.clip = musicClips[3];
            music.Play();
            sectionChange = false;
        }
        else if (SectionNumber == 4 && sectionChange == true) // section B
        {
            music.clip = musicClips[4];
            music.Play();
            sectionChange = false;
        }
        else
        {
            // nothing
        }

        if (running == true) // play the bell sound if we're running
        {
            playBell(); // method to play the bell sound
        }
    }

    private void playBell()
    {
        if (hasPlayed != true) // if we haven't played the bell sound
        {
            bell.Play(); // play it
            hasPlayed = true; // flip the switch to indicate we've played the bell sound
        }
    }

    private void sectionAudioChange() // manages the section change audio
    {
        if (lastSection == sectionNumber - 1) // if aor last section is one integer behind our current section
        {
            lastSection = sectionNumber; // update our last section
            sectionChange = true; // set section change to true (will chanbge the section music)
        }
    }

    private void musicManager() // stops music if we hit a trash can
    {
        if (player.GetComponent<PlayerController>().playerHit == true)
        {
            music.Stop();
            //Debug.Log("stop");
        }
    }
}
