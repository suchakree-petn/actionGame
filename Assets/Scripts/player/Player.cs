using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, IDamageable
{
    public float player_max_hp;
    public float hp;
    public bool Is_player_die = false;
    public bool Is_stun = false;
    public bool Is_onCD = false;
    public bool Is_KnockBack = false;



    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rbPlayer;
    private player_hp player_Hp;
    public player_movement player_Movement;
    public player_attack player_Attack;
    public PlayerInput playerInput;
    public PlayerInputActions playerInputActions;
    public bool Is_immortal;
    [SerializeField] List<GameObject> JoyStick;
    [SerializeField] GameOver gameOver;

    void Awake()
    {
        animator = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player_Hp = GetComponent<player_hp>();
        player_Movement = GetComponent<player_movement>();
        player_Attack = GetComponent<player_attack>();
        playerInputActions = new PlayerInputActions();
        playerInput = GetComponent<PlayerInput>();
        EnableMovePlayerInput();
        EnableAttackPlayerInput();
    }
    void Update()
    {

    }
    public void Do_Immortal(float sec)
    {
        StartCoroutine(Immortal(sec));
    }
    public void DisableMovePlayerInput()
    {
        playerInputActions.Player_Movement.Disable();
    }
    public void EnableMovePlayerInput()
    {
        playerInputActions.Player_Movement.Enable();
    }
    public void DisableAttackPlayerInput()
    {
        playerInputActions.Player_Attack.Disable();
    }
    public void EnableAttackPlayerInput()
    {
        playerInputActions.Player_Attack.Enable();
    }
    private void OnEnable()
    {
        player_Attack = GetComponent<player_attack>();
    }
    public void DamageReceive(float dmg)
    {
        if (Is_player_die == false && Is_immortal == false)
        {
            hp -= dmg;
            Check_Is_Die();
            SetHp();
            player_Attack.enabled = false;
            player_Attack.enabled = true;
            if (player_Attack.Is_charge)
            {
                player_Attack.Is_reloadScript = true;
            }
        }
        else
        {
            //Debug.Log("Immortal");
        }

    }
    private void Check_Is_Die()
    {
        if (hp <= 0)
        {
            Is_player_die = true;
            gameOver.OnStageOver();
        }
    }
    public void SetHp()
    {
        player_Hp.hp_body.value = hp;

    }
    public void knockBack(GameObject attacker, float knockBackRange)
    {
        if (Is_immortal == false)
        {
            Is_KnockBack = true;
            DisableJoyStick();
            Vector3 attacker_Pos = attacker.transform.position;
            Vector3 target_Pos = transform.position;
            Vector2 direction = target_Pos - attacker_Pos;
            rbPlayer.velocity = Vector2.zero;
            rbPlayer.AddForce(direction.normalized * knockBackRange, ForceMode2D.Force);
            Invoke("AfterKnockBack", 0.5f);
            player_Movement.Invoke("EnableCanMove", 0.5f);
            EnableJoyStick();
            StartCoroutine(IEnum.KBDelay(this.gameObject));
        }


    }
    void EnableJoyStick()
    {
        foreach (GameObject go in JoyStick)
        {
            go.SetActive(false);
        }
    }
    void DisableJoyStick()
    {
        foreach (GameObject go in JoyStick)
        {
            go.SetActive(false);
        }
    }

    void AfterKnockBack()
    {
        Is_KnockBack = false;
    }

    IEnumerator Immortal(float sec)
    {
        Is_immortal = true;
        yield return new WaitForSeconds(sec);
        Is_immortal = false;
    }
}
