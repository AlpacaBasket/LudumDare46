using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{

    private Rigidbody rb;

    private float accelleration;
    private float topSpeed;
    private float decelleration;

    private float currentSpeed;

    // flags ay
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Change criteria to all surfaces
    private void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Ground")
        {
            grounded = true;
        }
    }

    // Change criteria to all surfaces
    private void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Ground")
        {
            grounded = false;
        }
    }

    void Run()
    {

    }

    void Jump()
    {

    }

    void Fall()
    {

    }



}
