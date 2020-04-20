using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class SquirrelController : MonoBehaviour
{

    public Rigidbody rb;
    public ParkController park; // Reference to park
    public Animator squirrelAnimator;
    public LayerMask groundedLayer;

    private float accelleration;
    private float pressureAccelleration;
    private float topSpeed;
    private float pressureTopSpeed;
    private float decelleration;
    private float groundTurnSpeed;
    private float airTurnSpeed;
    private Vector3 movement;
    public float input;

    private float currentSpeed;
    
    public enum states {Stand, Skating, Air, Manual, Grind, Tricking, Bail};
    public states state;

    // flags ay
    public bool grounded;
    private int groundCollisionsTouching = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        currentSpeed = 0;

        // Set properties of skater
        accelleration = 1;
        pressureAccelleration = 2;
        topSpeed = 20;
        pressureTopSpeed = 30;
        groundTurnSpeed = 1;
        airTurnSpeed = 1;
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

        if (input > 0 && (state == states.Stand) || (state == states.Skating))
        {
            Skate();
        }

    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.SphereCast(transform.position, 0.05f, -transform.up, out hit, 2f, groundedLayer))
        {
            grounded = true;
        } else
        {
            grounded = false;
        }
    }

    /* big charlie, alternative method above
    // Change criteria to all surfaces
    private void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.CompareTag("Ground"))
        {
            groundCollisionsTouching++;
            grounded = true;
        }
    }

    // Change criteria to all surfaces
    private void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.CompareTag("Ground"))
        {
            groundCollisionsTouching--;
            if(groundCollisionsTouching <= 0)
            grounded = false;
        }
    }*/

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
        if (Input.GetButton("Fire1"))
        {
            squirrelAnimator.SetBool("Pressuring", true);
            if (currentSpeed < pressureTopSpeed)
            {
                currentSpeed += pressureAccelleration;
            }
        } else
        {
            squirrelAnimator.SetBool("Pressuring", false);
        }

        // Turn
        transform.Rotate(Vector3.up, (Input.GetAxis("Horizontal") * groundTurnSpeed));

        // Slow down to stand if holding back

        //movement = new Vector3(0.0f, 0.0f, currentSpeed); big charlie
        movement = transform.forward * currentSpeed;
        //rb.transform.Translate(movement); big charlie
        rb.velocity = movement;

    }

    private void AnimateSkate()
    {
        //TODO: Add animation
        squirrelAnimator.SetTrigger("Push_Off");
    }

    // Falling in air, use instead of gravity later
    void Fall()
    {

    }

    void Ollie()
    {
        AnimateOllie();
        park.PerformedTrick("ollie");
    }

    private void AnimateOllie()
    {
        //TODO: Add animation
    }

    void Manual()
    {
        state = states.Manual;
        AnimateManual();
        park.PerformedTrick("manual");
    }

    private void AnimateManual()
    {
        //TODO: Add animation
    }

    void NoseManual()
    {
        state = states.Manual;
        AnimateNoseManual();
        park.PerformedTrick("nosemanual");
    }

    private void AnimateNoseManual()
    {
        //TODO: Add animation
    }

    void Grind()
    {
        state = states.Grind;
        AnimateGrind();
        park.PerformedTrick("grind");
    }

    private void AnimateGrind()
    {
        //TODO: Add animation
    }

    void Frontside180()
    {
        state = states.Tricking;
        AnimateFrontside180();
        park.PerformedTrick("frontside180");
    }

    private void AnimateFrontside180()
    {
        //TODO: Add animation
    }

    void Backside180()
    {
        state = states.Tricking;
        AnimateBackside180();
        park.PerformedTrick("backside180");
    }

    private void AnimateBackside180()
    {
        //TODO: Add animation
    }

    void PopShoveIt()
    {
        state = states.Tricking;
        AnimatePopShoveIt();
        park.PerformedTrick("popshoveit");
    }

    private void AnimatePopShoveIt()
    {
        //TODO: Add animation
    }

    void FrontsidePopShoveIt()
    {
        state = states.Tricking;
        AnimateFrontsidePopShoveIt();
        park.PerformedTrick("frontsidepopshoveit");
    }

    private void AnimateFrontsidePopShoveIt()
    {
        //TODO: Add animation
    }

    void Kickflip()
    {
        state = states.Tricking;
        AnimateKickflip();
        park.PerformedTrick("kickflip");
    }

    private void AnimateKickflip()
    {
        //TODO: Add animation
    }

    void Heelflip()
    {
        state = states.Tricking;
        AnimateHeelflip();
        park.PerformedTrick("heelflip");
    }

    private void AnimateHeelflip()
    {
        //TODO: Add animation
    }

    void Impossible()
    {
        state = states.Tricking;
        AnimateImpossible();
        park.PerformedTrick("impossible");
    }

    private void AnimateImpossible()
    {
        //TODO: Add animation
    }

    void Backflip()
    {
        state = states.Tricking;
        AnimateBackflip();
        park.PerformedTrick("backflip");
    }

    private void AnimateBackflip()
    {
        //TODO: Add animation
    }

    void Frontflip()
    {
        state = states.Tricking;
        AnimateFrontflip();
        park.PerformedTrick("frontflip");
    }

    private void AnimateFrontflip()
    {
        //TODO: Add animation
    }

    void ClockwiseRoll()
    {
        state = states.Tricking;
        AnimateClockwiseRoll();
        park.PerformedTrick("clockwiseroll");
    }

    private void AnimateClockwiseRoll()
    {
        //TODO: Add animation
    }

    void CounterclockwiseRoll()
    {
        state = states.Tricking;
        AnimateCounterclockwiseRoll();
        park.PerformedTrick("counterclockwiseroll");
    }

    private void AnimateCounterclockwiseRoll()
    {
        //TODO: Add animation
    }

    // Fall off your board
    // Classic bail boy
    void Bail()
    {
        state = states.Bail;
        AnimateBail();
        park.PerformedTrick("bail");
    }

    private void AnimateBail()
    {
        //TODO: Add animation
    }
}
