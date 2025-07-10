using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // we should probably put a bunch of this code in methods lol


    // Game States
    public bool gameStart; // to check if we've started the game, running is dependent on this
    public bool running; // to check if we're running
    private bool beginMusic = false; // to signal the music transition when we start the game
    [SerializeField] private float runTime; // the run time for each section

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
    [SerializeField] private GameObject mainCam;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float camSpeed;
    private Vector3 houseCamPos;
    private Vector3 endCamPos;
    private Vector3 endPlayerPos;
    [SerializeField] private GameObject CloudSpawner;
    [SerializeField] private GameObject BushSpawner;
    [SerializeField] private GameObject CloseBushSpawner;
    [SerializeField] private GameObject ObstacleSpawner;
    [SerializeField] private UIManager uiManager;

    public float RunTime
    {
        get
        {
            return runTime;
        }
    }
    [SerializeField] private int lastSection; // to track our last section (for audio)
    [SerializeField] private int sectionNumber; // to track our current section
    public int SectionNumber
    {
        get
        {
            return sectionNumber;
        }
    }

    void Awake()
    {
        running = false; // we won't be running at the launch
        gameStart = false; // the game has not started when we launch
        sectionNumber = 0; // our first section number (section a) is 0
        lastSection = SectionNumber; // set our last section to the section number (will be 0 at the beginning of the game)
        player.GetComponent<SpriteRenderer>().enabled = false; // our sprite is not rendered in

        // fill in the array - these values need to have an AudioClip assigned in the editor
        musicClips[0] = sectionA; 
        musicClips[1] = section1;
        musicClips[2] = section2;
        musicClips[3] = section3;
        musicClips[4] = sectionB;
        musicClips[5] = ambience;


        houseCamPos = new Vector3(27.5f, 1f, -10f);
        endCamPos = new Vector3(27.5f, 10f, -10f);
        endPlayerPos = new Vector3(34.5f, -3.18f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameStart == true) // commence running if the game has started
        {
            running = true;
        }
        else
        {
            running = false;
        }

        if (running) // tracks our progress in each section
        {
            runTime += Time.fixedDeltaTime; // increase run time 
            if (runTime >= 14.769) // if we reach the end of a section 
            {
                runTime = 0f; // reset the run time
                sectionNumber++; // increase the section number
            }
        }
        else
        {

        }

        // initialising methods
        activateSprite(); // see method

        // music methods
        musicManager(); // see method
        initialiseGameMusic(); // see method
        if (running == true) // see method
        {
            sectionMusic();
        }




        //EndingCutscene
        if(SectionNumber >=4)
        {
            CloudSpawner.SetActive(false);
            CloseBushSpawner.SetActive(false);
            BushSpawner.SetActive(false);
            ObstacleSpawner.SetActive(false);
            Destroy(GameObject.FindGameObjectWithTag("Obstacle"));

            if(mainCam.transform.position.x == endCamPos.x)
            {
                camSpeed = 3f;
                mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, endCamPos, camSpeed * Time.fixedDeltaTime);
            }
            else
            {
                mainCam.transform.position = Vector3.MoveTowards(mainCam.transform.position, houseCamPos, camSpeed * Time.fixedDeltaTime);
            }
            player.transform.position = Vector3.MoveTowards(player.transform.position, endPlayerPos, playerSpeed * Time.fixedDeltaTime);

            if(mainCam.transform.position == endCamPos)
            {
                player.GetComponent<PlayerController>().playerHit = true;
                uiManager.endUIManager();
            }
            
        }
        

    }

    private void sectionMusic() // changes the section music based on the section number
    {
        sectionAudioChange(); // see method
        if (SectionNumber == 0 && sectionChange == true) // section A
        {
            music.clip = musicClips[0];
            music.Play();
            sectionChange = false;
        }
        else if (SectionNumber == 1 && sectionChange == true) // section 1
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
            playBell(); // see method
        }
    }

    private void playBell() // play the bell sound
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
        if (player.GetComponent<PlayerController>().playerHit == true) // if the player has been hit
        {
            music.Stop();//stop the music
            //Debug.Log("stop");
        }
    }

    private void activateSprite() // activates player sprite if we've started game
    {
        if (gameStart == true) // if the game has started
        {
            player.GetComponent<SpriteRenderer>().enabled = true; // enable sprite
        }
    }

    void initialiseGameMusic() // starts our section transitions when we start the game
    {
        if (gameStart == true && beginMusic == false) // if the game has started and we haevn't started the music
        {
            sectionChange = true; // start changing the section music (changes to Section A)
            beginMusic = true; // let the system knwo we've started the music
        }
    }
}
