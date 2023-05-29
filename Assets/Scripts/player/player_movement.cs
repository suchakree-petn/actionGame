using UnityEngine;

public class player_movement : MonoBehaviour
{

    [SerializeField] private float player_move_speed = 7f;
    [SerializeField] private int directionCount = 0;
    [SerializeField] private bool Is_W = false;
    [SerializeField] private bool Is_A = false;
    [SerializeField] private bool Is_S = false;
    [SerializeField] private bool Is_D = false;
    public Vector2 movement;
    private Player player;
    private player_attack player_Attack;
    public bool Can_Walk = true;


    void Start()
    {
        player = GetComponent<Player>();
        player_Attack = GetComponent<player_attack>();
    }


    void Update()
    {
        if (player_Attack.Is_charge || player.Is_KnockBack)
        {
            Can_Walk = false;
        }
        else
        {
            Can_Walk = true;
        }
        movement = player.playerInputActions.Player_Movement.walk.ReadValue<Vector2>();
        if (movement != Vector2.zero && Can_Walk)
        {
            
            CheckWalkCondition(movement);
        }
        WASD_State();
        CheckMovement();
    }
    void FixedUpdate()
    {
        resetWalkAnimState();
    }

    public void CheckWalkCondition(Vector2 movement)
    {
        walk(movement);
        //GetInputMovement();
        // if (
        //     //directionCount > 0 &&
        //     this.Can_Walk == true
        //     )
        // {
        // }
    }
    // void GetInputMovement(InputAction.CallbackContext context)
    // {
    //     // movement.x = Input.GetAxisRaw("Horizontal");
    //     // movement.y = Input.GetAxisRaw("Vertical");
    // }
    void resetWalkAnimState()
    {
        player.animator.SetBool("Is_walk_side", false);
        player.animator.SetBool("Is_walk_back", false);
        player.animator.SetBool("Is_walk_front", false);
    }
    void walk(Vector2 movement)
    {
        // if ((Is_A == true || Is_D == true) && Is_W == false && Is_S == false)
        // {
        //     if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        //     {
        //         rbPlayer.velocity = Vector2.zero;
        //     }
        //     if (Is_A)
        //     {
        //         this.spriteRenderer.flipX = true;
        //     }
        //     else if (Is_D)
        //     {
        //         this.spriteRenderer.flipX = false;
        //     }
        // }
        // else if (Is_A == false && (Is_W == true || Is_S == true) && Is_D == false)
        // {
        //     if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        //     {
        //         rbPlayer.velocity = Vector2.zero;
        //     }
        //     rbPlayer.AddForce(new Vector2(0f, movement.y).normalized * player_move_speed, ForceMode2D.Impulse);
        // }
        // else
        // {
        //     if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) && Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        //     {
        //         rbPlayer.velocity = Vector2.zero;
        //     }
        //     rbPlayer.AddForce(movement.normalized * player_move_speed, ForceMode2D.Impulse);
        // }
        player.rbPlayer.MovePosition(player.rbPlayer.position + movement.normalized * player_move_speed * Time.fixedDeltaTime);
        AnimationWalk();
    }
    void AnimationWalk()
    {
        if (Is_A)
        {
            player.spriteRenderer.flipX = false;
        }
        else if (Is_D)
        {
            player.spriteRenderer.flipX = true;
        }
        if (Is_A || Is_D)
        {
            player.animator.SetBool("Is_walk_side", true);
        }

        if (Is_W && Is_D == false && Is_A == false)
        {
            player.animator.SetBool("Is_walk_side", false);
            player.animator.SetBool("Is_walk_back", true);

        }
        else if (Is_S && Is_A == false && Is_D == false)
        {
            player.animator.SetBool("Is_walk_side", false);
            player.animator.SetBool("Is_walk_front", true);
        }
    }
    void WASD_State()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Is_W = true;
            directionCount++;
        }
        else if (Input.GetKeyUp(KeyCode.W) && directionCount > 0)
        {
            Is_W = false;
            directionCount--;

        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            Is_A = true;
            player.spriteRenderer.flipX = false;
            directionCount++;

        }
        else if (Input.GetKeyUp(KeyCode.A) && directionCount > 0)
        {
            Is_A = false;
            directionCount--;

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            Is_S = true;
            directionCount++;

        }
        else if (Input.GetKeyUp(KeyCode.S) && directionCount > 0)
        {
            Is_S = false;
            directionCount--;

        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            Is_D = true;
            directionCount++;

        }
        else if (Input.GetKeyUp(KeyCode.D) && directionCount > 0)
        {
            Is_D = false;
            directionCount--;

        }
    }
    void CheckMovement()
    {
        if (movement.x > 0)
        {
            Is_A = false;
            Is_D = true;
        }
        else if (movement.x < 0)
        {
            Is_D = false;
            Is_A = true;
        }
        if (movement.y > 0)
        {
            Is_W = true;
            Is_S = false;
        }
        else if (movement.y < 0)
        {
            Is_W = false;
            Is_S = true;
        }
        if (movement == new Vector2(0, 0))
        {
            resetMoveState();
        }
    }
    private void resetMoveState()
    {
        this.Is_A = false;
        this.Is_D = false;
        this.Is_W = false;
        this.Is_S = false;
    }
    void EnableCanMove()
    {
        Can_Walk = true;
    }
    public void DisableMove()
    {
        this.resetWalkAnimState();
        this.resetMoveState();
        this.directionCount = 0;
        player.animator.SetTrigger("Idle");
        this.enabled = false;


    }
    public void EnableMove()
    {
        this.enabled = true;
    }
}
