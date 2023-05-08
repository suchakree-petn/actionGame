using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class RobotControllerScript : MonoBehaviour
{

    public float maxSpeed = 10f;
    bool facingRight = true;
    private Rigidbody2D rb2D;
    Animator anim;

    public bool grounded = false;
    public Transform groundCheck;
    float groundRadius = 0.2f;
    public LayerMask whatIsGround;
    public float jumpForce = 350f;
    public float move;
    public bool Is_Jump = false;
    public void OnWalk(InputAction.CallbackContext context)
    {
        move = context.ReadValue<float>();
    }


    void FixedUpdate()
    {
        //check if player is on the ground or not
        grounded = Physics2D.OverlapCircle(groundCheck.position,
                                            groundRadius,
                                            whatIsGround);
        anim.SetBool("Ground", grounded);
        anim.SetFloat("vSpeed", rb2D.velocity.y);

        //		if (!grounded)
        //			return;

        // float move = Input.GetAxis("Horizontal");
        //print (move);
        anim.SetFloat("Speed", Mathf.Abs(move));
        rb2D.velocity = new Vector2(move * maxSpeed, rb2D.velocity.y);
        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)
        {
            Flip();
        }
    }
    public void Onjump(InputAction.CallbackContext context)
    {
        float input = context.ReadValue<float>();
        if (input > 0) { Is_Jump = true; }
        if (input <= 0) { Is_Jump = false; }
    }
    void Update()
    {
        if (grounded && Is_Jump)
        {
            anim.SetBool("Ground", false);
            rb2D.AddForce(new Vector2(0, jumpForce));
        }
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void SwipeToWalk(float step)
    {
        move = step;
    }
    public void SwipeToJump(bool Jump)
    {
        Is_Jump = Jump;
    }

}
