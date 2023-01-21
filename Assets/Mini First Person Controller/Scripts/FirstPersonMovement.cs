using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    public Animator animator;
    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> Functions to override movement speed. Will use the last added override. </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();



    void Awake()
    {
        // Get the rigidbody on this.
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Update IsRunning from input.
        IsRunning = canRun && Input.GetKey(runningKey);

        // Get targetMovingSpeed.
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            animator.SetBool("RunForward",true);
            animator.SetBool("RunBackward",false);
        }
        if(Input.GetAxis("Horizontal") == 0)
        {
            animator.SetBool("RunForward",false);
            animator.SetBool("RunBackward",false);
        }
        if(Input.GetAxis("Horizontal") < 0)
        {
            animator.SetBool("RunForward",false);
            animator.SetBool("RunBackward",true);
        }

        if(Input.GetAxis("Vertical") > 0)
        {
            animator.SetBool("RunLeft",false);
            animator.SetBool("RunRight",true);
        }
        if(Input.GetAxis("Vertical") == 0)
        {
            animator.SetBool("RunLeft",false);
            animator.SetBool("RunRight",false);
        }        
        if(Input.GetAxis("Vertical") < 0)
        {
            animator.SetBool("RunLeft",true);
            animator.SetBool("RunRight",false);
        }
        // Get targetVelocity from input.
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Apply movement.
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);
    }
}