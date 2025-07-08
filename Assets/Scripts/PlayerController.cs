using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private InputAction movement;
    private Rigidbody2D rb2d;

    public float pushUp; // the variable for pushing the pakyer up
    public float pushForward;

    private LayerMask player;
    private LayerMask obstacles;

    public GameObject gameManager;



    void Awake()
    {
        controls = new PlayerControls();
        movement = controls.Movement.Jump;
        movement.performed += jump;
        player = LayerMask.GetMask("Player");
        obstacles = LayerMask.GetMask("Obstacles");
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnEnable()
    {
        movement.Enable();
    }

    void jump(InputAction.CallbackContext context)
    {
        rb2d.AddForce(Vector3.up * pushUp, ForceMode2D.Impulse);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.IsTouchingLayers(3) == false)
        {
            stunned();
        }
    }

    void stunned()
    {
            gameManager.GetComponent<GameManager>().running = false;
            rb2d.AddForce(Vector3.right * pushForward, ForceMode2D.Impulse);
            Debug.Log("You've hit the trash can");
        }
    }

