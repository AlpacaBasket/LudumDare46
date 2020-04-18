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
        state = states.Skating;
        AnimateSkate();

        // Start moving from stand if you hold forward

        // Go faster if holding ollie

        // Slow down to stand if holding back

    }

    private void AnimateSkate()
    {
        throw new NotImplementedException();
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
        throw new NotImplementedException();
    }

    void Manual()
    {
        state = states.Manual;
        AnimateManual();
    }

    private void AnimateManual()
    {
        throw new NotImplementedException();
    }

    void NoseManual()
    {
        state = states.Manual;
        AnimateNoseManual();
    }

    private void AnimateNoseManual()
    {
        throw new NotImplementedException();
    }

    void Grind()
    {
        state = states.Grind;
        AnimateGrind();
    }

    private void AnimateGrind()
    {
        throw new NotImplementedException();
    }

    void Frontside180()
    {
        state = states.Tricking;
        AnimateFrontside180();
    }

    private void AnimateFrontside180()
    {
        throw new NotImplementedException();
    }

    void Backside180()
    {
        state = states.Tricking;
        AnimateBackside180();
    }

    private void AnimateBackside180()
    {
        throw new NotImplementedException();
    }

    void PopShoveIt()
    {
        state = states.Tricking;
        AnimatePopShoveIt();
    }

    private void AnimatePopShoveIt()
    {
        throw new NotImplementedException();
    }

    void FrontsidePopShoveIt()
    {
        state = states.Tricking;
        AnimateFrontsidePopShoveIt();
    }

    private void AnimateFrontsidePopShoveIt()
    {
        throw new NotImplementedException();
    }

    void Kickflip()
    {
        state = states.Tricking;
        AnimateKickflip();
    }

    private void AnimateKickflip()
    {
        throw new NotImplementedException();
    }

    void Heelflip()
    {
        state = states.Tricking;
        AnimateHeelflip();
    }

    private void AnimateHeelflip()
    {
        throw new NotImplementedException();
    }

    void Impossible()
    {
        state = states.Tricking;
        AnimateImpossible();
    }

    private void AnimateImpossible()
    {
        throw new NotImplementedException();
    }

    void Backflip()
    {
        state = states.Tricking;
        AnimateBackflip();
    }

    private void AnimateBackflip()
    {
        throw new NotImplementedException();
    }

    void Frontflip()
    {
        state = states.Tricking;
        AnimateFrontflip();
    }

    private void AnimateFrontflip()
    {
        throw new NotImplementedException();
    }

    void ClockwiseRoll()
    {
        state = states.Tricking;
        AnimateClockwiseRoll();
    }

    private void AnimateClockwiseRoll()
    {
        throw new NotImplementedException();
    }

    void CounterclockwiseRoll()
    {
        state = states.Tricking;
        AnimateCounterclockwiseRoll();
    }

    private void AnimateCounterclockwiseRoll()
    {
        throw new NotImplementedException();
    }

    // Fall off your board
    void Bail()
    {
        state = states.Bail;
        AnimateBail();
    }

    private void AnimateBail()
    {
        throw new NotImplementedException();
    }
}
