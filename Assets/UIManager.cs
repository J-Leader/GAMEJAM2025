using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameObject startText;
    public GameObject resetText;
    public GameObject jumpText;
    private float textDespawnTimer = 5.0f;

    void Awake()
    {
        startText.GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        startUIManager();
        resetUIManager();
        jumpTutorialText();
    }

    void startUIManager()
    {
        if (gameManager.GetComponent<GameManager>().gameStart == true)
        {
            startText.SetActive(false);
        }
    }

    void resetUIManager()
    {
        if (player.GetComponent<PlayerController>().playerHit == true)
        {
            resetText.SetActive(true);
            Debug.Log("reset?");
        }
        else
        {
            resetText.SetActive(false);
        }
    }

    void jumpTutorialText()
    {
        if (gameManager.GetComponent<GameManager>().gameStart == true && gameManager.GetComponent<GameManager>().running == true)
        {
            jumpText.SetActive(true);
            textDespawnTimer -= Time.deltaTime;
            if (textDespawnTimer <= 0)
            {
                jumpText.SetActive(false);
            }
        }
    }
}
