using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private InputAction movement;
    //private Rigidbody2D rb2d;

    public float push; // the variable for pushing the pakyer up

    private LayerMask player;
    private LayerMask obstacles;



    void Awake()
    {
        controls = new PlayerControls();
        movement = controls.Movement.Jump;
        movement.performed += jump;
        player = LayerMask.GetMask("Player");
        obstacles = LayerMask.GetMask("Obstacles");
    }

    // Update is called once per frame
    void Update()
    {
        stunned();
    }

    void OnEnable()
    {
        movement.Enable();
    }

    void jump(InputAction.CallbackContext context)
    {
        transform.Translate(Vector3.up * push);
    }

    void stunned()
    {
        if (gameObject.GetComponent<Collider2D>().IsTouchingLayers(obstacles)) {
            Debug.Log("Yeah m8");
        }
    }
}
