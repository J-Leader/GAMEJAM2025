using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Player variables
    private PlayerControls controls;
    private InputAction movement;
    private InputAction startGame;
    private InputAction resetGame;
    private Rigidbody2D rb2d;
    public float pushUp; // the variable for pushing the pakyer up
    public float pushForward;
    public bool playerHit;
    public float jumpThreshold;
    public Animator animator;
    public AudioSource jumping;
    public AudioSource impact;

    // Layers
    private LayerMask player;
    private LayerMask obstacles;

    // Gameobject
    public GameObject gameManager;
    public Collider2D endPoint;

    public bool hitVibration;
    public float vibratioTimer;



    void Awake() // initalise variables
    {
        controls = new PlayerControls();
        movement = controls.Movement.Jump;
        startGame = controls.Interaction.Start;
        resetGame = controls.Interaction.Reset;
        movement.performed += jump;
        startGame.performed += start;
        resetGame.performed += reset;
        player = LayerMask.GetMask("Player");
        obstacles = LayerMask.GetMask("Obstacles");
        rb2d = GetComponent<Rigidbody2D>();
        playerHit = false;
        hitVibration = false;
        vibratioTimer = 0.5f;
    }

    void OnEnable() // enable the interactions
    {
        startGame.Enable();
        resetGame.Enable();
    }

    void Update()
    {
        if (transform.position.y > jumpThreshold)
        {
            movement.Disable();
        }
        else
        {
            movement.Enable();
        }

        jumpAnimation();
        fallingAnimation();
        sfx();
        // Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("Landing"));

        impactVibration();
        binVibration();

    }

    void jump(InputAction.CallbackContext context) // jump action pushes the player up
    {
        rb2d.AddForce(Vector3.up * pushUp, ForceMode2D.Impulse);
    }

    void start(InputAction.CallbackContext context) // start action begins the game
    {
        gameManager.GetComponent<GameManager>().gameStart = true;
    }

    void reset(InputAction.CallbackContext context) // reset action restarts the game if the player has been hit
    {
        if (playerHit == true)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            playerHit = false;
        }
    }

    void OnTriggerExit2D(Collider2D other) // stops the game if the player has hit a trash can
    {
        if (other.IsTouchingLayers(3) == false)
        {
            stunned();
            playerHit = true;
        }
    }

    void stunned() // method for stunning the player if they hit a trach can
    {
        gameManager.GetComponent<GameManager>().gameStart = false;
        rb2d.AddForce(Vector3.right * pushForward, ForceMode2D.Impulse);
    }

    void jumpAnimation()
    {
        if (transform.position.y > jumpThreshold)
        {
            animator.SetBool("isJumping", true);
        }

        if (transform.position.y <= jumpThreshold)
        {
            animator.SetBool("isJumping", false);
        }
    }

    void fallingAnimation()
    {
        if (playerHit == true)
        {
            animator.SetBool("hasFallen", true);
        }
        else
        {
            animator.SetBool("hasFallen", false);
        }
    }

    void sfx()
    {
        if (animator.GetBool("isJumping") && !jumping.isPlaying)
        {
            jumping.Play();
        }

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Landing") && !impact.isPlaying)
        {
            impact.Play();
            Debug.Log("Played");
        }
    }

    void impactVibration()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Landing"))
        {
            Gamepad.current.SetMotorSpeeds(.1f, .1f);
        }
        else
        {
            Gamepad.current.SetMotorSpeeds(0f, 0f);
        }
    }

    void binVibration()
    {
        if (hitVibration == true)
        {
            vibratioTimer = vibratioTimer - Time.deltaTime;
            if (vibratioTimer >= 0)
            {
                Gamepad.current.SetMotorSpeeds(.5f, .5f);
            }
            else
            {
                Gamepad.current.SetMotorSpeeds(0f, 0f);
            }
        }

        if (playerHit == true)
        {
            hitVibration = true;
            Debug.Log("cuck");
        }
        Debug.Log(vibratioTimer);
    }

    }
    

