using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelController : MonoBehaviour
{

    Rigidbody rb;

    private float accelleration;
    private float topSpeed;
    private float decelleration;
    private Vector3 movement;
    public float input;

    private float currentSpeed;
    
    public enum states {Stand, Skating, Air, Manual, Grind, Tricking, Bail};
    public states state;

    // flags ay
    public bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentSpeed = 0;

        // Set properties of skater
        accelleration = 1;
        topSpeed = 10;
        decelleration = 1;
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

        input = Input.GetAxis("Vertical");

        if (input > 0 && state == states.Stand)
        {
            Skate();
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
        state = states.Skating;
        AnimateSkate();

        input = Input.GetAxis("Vertical");

        // Start moving from stand if you hold forward
        if (input > 0)
        {
            // Check if you can accellerate
            // Go faster until you reach max speed
            // Speed is unchanged if at or past maximum speed
            if (currentSpeed < topSpeed)
            {
                currentSpeed += accelleration;
            }

        }

        // Go faster if holding ollie

        // Slow down to stand if holding back

        movement = new Vector3(0.0f, 0.0f, currentSpeed);
        rb.transform.Translate(movement);

    }

    private void AnimateSkate()
    {
        //TODO: Add animation
    }

    // Falling in air, use instead of gravity later
    void Fall()
    {

    }

    void Ollie()
    {
        AnimateOllie();
    }

    private void AnimateOllie()
    {
        //TODO: Add animation
    }

    void Manual()
    {
        state = states.Manual;
        AnimateManual();
    }

    private void AnimateManual()
    {
        //TODO: Add animation
    }

    void NoseManual()
    {
        state = states.Manual;
        AnimateNoseManual();
    }

    private void AnimateNoseManual()
    {
        //TODO: Add animation
    }

    void Grind()
    {
        state = states.Grind;
        AnimateGrind();
    }

    private void AnimateGrind()
    {
        //TODO: Add animation
    }

    void Frontside180()
    {
        state = states.Tricking;
        AnimateFrontside180();
    }

    private void AnimateFrontside180()
    {
        //TODO: Add animation
    }

    void Backside180()
    {
        state = states.Tricking;
        AnimateBackside180();
    }

    private void AnimateBackside180()
    {
        //TODO: Add animation
    }

    void PopShoveIt()
    {
        state = states.Tricking;
        AnimatePopShoveIt();
    }

    private void AnimatePopShoveIt()
    {
        //TODO: Add animation
    }

    void FrontsidePopShoveIt()
    {
        state = states.Tricking;
        AnimateFrontsidePopShoveIt();
    }

    private void AnimateFrontsidePopShoveIt()
    {
        //TODO: Add animation
    }

    void Kickflip()
    {
        state = states.Tricking;
        AnimateKickflip();
    }

    private void AnimateKickflip()
    {
        //TODO: Add animation
    }

    void Heelflip()
    {
        state = states.Tricking;
        AnimateHeelflip();
    }

    private void AnimateHeelflip()
    {
        //TODO: Add animation
    }

    void Impossible()
    {
        state = states.Tricking;
        AnimateImpossible();
    }

    private void AnimateImpossible()
    {
        //TODO: Add animation
    }

    void Backflip()
    {
        state = states.Tricking;
        AnimateBackflip();
    }

    private void AnimateBackflip()
    {
        //TODO: Add animation
    }

    void Frontflip()
    {
        state = states.Tricking;
        AnimateFrontflip();
    }

    private void AnimateFrontflip()
    {
        //TODO: Add animation
    }

    void ClockwiseRoll()
    {
        state = states.Tricking;
        AnimateClockwiseRoll();
    }

    private void AnimateClockwiseRoll()
    {
        //TODO: Add animation
    }

    void CounterclockwiseRoll()
    {
        state = states.Tricking;
        AnimateCounterclockwiseRoll();
    }

    private void AnimateCounterclockwiseRoll()
    {
        //TODO: Add animation
    }

    // Fall off your board
    void Bail()
    {
        state = states.Bail;
        AnimateBail();
    }

    private void AnimateBail()
    {
        //TODO: Add animation
    }
}
