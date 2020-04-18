using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{

    Rigidbody rb;

    private float accelleration;
    private float topSpeed;
    private float decelleration;

    private float currentSpeed;
    
    public enum states { Stand, Skating, Air, Manual, Grind, Tricking, Bail};
    public states state;

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

        // Very oversimplified, just to test the state system
        if (grounded)
        {
            state = states.Stand;
        }
        else
        {
            state = states.Air;
        }

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

    // Skate forward on the ground
    void Skate()
    {

    }

    // Falling in air, use instead of gravity later
    void Fall()
    {

    }

    void Ollie()
    {

    }

    void Manual()
    {

    }

    void NoseManual()
    {

    }

    void Grind()
    {

    }


    void Frontside180()
    {

    }

    void Backside180()
    {

    }

    void PopShoveIt()
    {

    }

    void FrontsidePopShoveIt()
    {

    }

    void Kickflip()
    {

    }

    void Heelflip()
    {

    }

    void Impossible()
    {

    }

    void Backflip()
    {

    }

    void Frontflip()
    {

    }

    void ClockwiseRoll()
    {

    }

    void CounterclockwiseRoll()
    {

    }


}
