using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject gameManager;
    public GameObject startText;
    public GameObject resetText;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        startUIManager();
        resetUIManager();
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
}
