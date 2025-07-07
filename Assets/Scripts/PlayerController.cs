using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerControls controls;
    private InputAction movement;
    //private Rigidbody2D rb2d;
    public float push;



    void Awake()
    {
        controls = new PlayerControls();
        movement = controls.Movement.Jump;
        movement.performed += jump;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }

    void OnEnable()
    {
        movement.Enable();
    }

    void jump(InputAction.CallbackContext context)
    {
        transform.Translate(Vector3.up * push);
    }
}
