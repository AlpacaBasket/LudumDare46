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
    private float jumpSpeed;
    private float gravity;
    private Vector3 movement;
    public float input;

    private float currentSpeed;
    public Trick currentTrick;
    
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
        currentTrick = new ollie();

        // Set properties of skater
        accelleration = 1;
        pressureAccelleration = 2;
        topSpeed = 15;
        pressureTopSpeed = 30;
        groundTurnSpeed = 1;
        airTurnSpeed = 1;
        jumpSpeed = 40;
        decelleration = 1;
        gravity = -5;
    }

    // Update is called once per frame
    void Update()
    {

        input = Input.GetAxis("Vertical");

        Fall();

        // Landed
        if ((state == states.Air) && grounded)
        {
            state = states.Stand;
        }

        // Classic bail boy
        if ((state == states.Tricking && grounded))
        {
            Bail();
        }

        if ((state == states.Stand || state == states.Skating) && Input.GetButtonDown("Manual"))
        {
            Manual();
        }

        if (input > 0 && (state == states.Stand) || (state == states.Skating))
        {
            Skate();
        }

        if (grounded && Input.GetButtonUp("Jump"))
        {
            Ollie();
        }

        if ((state == states.Air) && Input.GetButtonDown("Flip"))
        {
            if (Input.GetAxis("Horizontal") > 0) // Right
            {
                Kickflip();
            }
            else if (Input.GetAxis("Horizontal") < 0) // Left
            {
                Heelflip();
            }
            else if (Input.GetAxis("Vertical") > 0) // Up
            {
                Impossible();
            }
            else if (Input.GetAxis("Vertical") < 0) // Down
            {
                PopShoveIt();
            }
        }

        if (!grounded && (state != states.Tricking))
        {
            state = states.Air;
        }

        
        if (grounded) // Ground turn
        {
            transform.Rotate(Vector3.up, (Input.GetAxis("Horizontal") * groundTurnSpeed));
        }
        else // Air turn
        {
            transform.Rotate(Vector3.up, (Input.GetAxis("Horizontal") * airTurnSpeed));
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
        if (Input.GetButton("Jump"))
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

        // Slow down to stand if holding back

        movement = transform.forward * currentSpeed;
        rb.velocity = movement;

    }

    private void AnimateSkate()
    {
        squirrelAnimator.SetTrigger("Push_Off");
    }

    // Falling in air, use instead of gravity later
    void Fall()
    {
        movement = transform.up * gravity;
        rb.velocity = movement;
    }

    void Ollie()
    {
        AnimateOllie();
        currentTrick = new ollie();
        park.PerformedTrick(currentTrick);

        movement = transform.up * jumpSpeed;
        rb.velocity = movement;
    }

    private void AnimateOllie()
    {
        //TODO: Add animation
    }

    void Manual()
    {
        state = states.Manual;
        AnimateManual();
        currentTrick = new Manual();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateManual()
    {
        //TODO: Add animation
    }

    void NoseManual()
    {
        state = states.Manual;
        AnimateNoseManual();
        currentTrick = new noseManual();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateNoseManual()
    {
        //TODO: Add animation
    }

    void Grind()
    {
        state = states.Grind;
        AnimateGrind();
        currentTrick = new grind();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateGrind()
    {
        //TODO: Add animation
    }

    void Frontside180()
    {
        state = states.Tricking;
        AnimateFrontside180();
        currentTrick = new frontside180();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateFrontside180()
    {
        //TODO: Add animation
    }

    void Backside180()
    {
        state = states.Tricking;
        AnimateBackside180();
        currentTrick = new backside180();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateBackside180()
    {
        //TODO: Add animation
    }

    void PopShoveIt()
    {
        state = states.Tricking;
        AnimatePopShoveIt();
        currentTrick = new popshoveit();
        park.PerformedTrick(currentTrick);
    }

    private void AnimatePopShoveIt()
    {
        //TODO: Add animation
    }

    void FrontsidePopShoveIt()
    {
        state = states.Tricking;
        AnimateFrontsidePopShoveIt();
        currentTrick = new frontsidepopshoveit();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateFrontsidePopShoveIt()
    {
        //TODO: Add animation
    }

    void Kickflip()
    {
        state = states.Tricking;
        AnimateKickflip();
        currentTrick = new kickflip();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateKickflip()
    {
        //TODO: Add animation
    }

    void Heelflip()
    {
        state = states.Tricking;
        AnimateHeelflip();
        currentTrick = new heelflip();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateHeelflip()
    {
        //TODO: Add animation
    }

    void Impossible()
    {
        state = states.Tricking;
        AnimateImpossible();
        currentTrick = new impossible();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateImpossible()
    {
        //TODO: Add animation
    }

    void Backflip()
    {
        state = states.Tricking;
        currentTrick = new backflip();
        park.PerformedTrick(currentTrick);
    }

    void Frontflip()
    {
        state = states.Tricking;
        currentTrick = new frontflip();
        park.PerformedTrick(currentTrick);
    }

    void ClockwiseRoll()
    {
        state = states.Tricking;
        currentTrick = new clockwiseroll();
        park.PerformedTrick(currentTrick);
    }

    void CounterclockwiseRoll()
    {
        state = states.Tricking;
        currentTrick = new counterclockwiseroll();
        park.PerformedTrick(currentTrick);
    }

    // Fall off your board
    // Classic bail boy
    void Bail()
    {
        state = states.Bail;
        AnimateBail();
        currentTrick = new bail();
        park.PerformedTrick(currentTrick);
    }

    private void AnimateBail()
    {
        //TODO: Add animation
    }
}
