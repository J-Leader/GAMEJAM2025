using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    private Vector3 direction;
    public float movementSpeed;
    void Awake()
    {
        direction = new Vector3(movementSpeed, 0f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transform.position - (direction * Time.deltaTime);
    }
}
