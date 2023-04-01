using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public Camera cam;
    public GameObject priMagicBall;
    [SerializeField] private GameObject pointerPrefab;
    [SerializeField] private GameObject pointerAttack;
    [SerializeField] private Vector2 mousePos;
    private Vector2 direction;
    private float angle;
    public float attackSpd = 0.1f;
    public float chargeSpeed = 1f;
    public float chargeTime;
    public bool Is_charge = false;
    public float maxCharge = 1;
    public float minCharge = 0.02f;
    public bool Is_priChargeCD = false;
    public bool Is_reloadScript = false;
    public bool Is_hold;
    public bool Can_Attack = true;
    public int chargeState = 0;


    [SerializeField] private player_movement player_Movement;
    private Player player;
    public Player_Mana player_Mana;
    void Start()
    {
        cam = Camera.main;
        player = GetComponent<Player>();
        player_Movement = GetComponent<player_movement>();
        InitialPointer();
    }

    void Update()
    {
        mousePos = player.playerInputActions.Player_Attack.PriAttack.ReadValue<Vector2>();
        if (mousePos != Vector2.zero)
        {
            Is_charge = true;

        }
        else if (mousePos == Vector2.zero)
        {
            Is_charge = false;
        }
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Is_charge)
        {
            direction = mousePos; // - (Vector2)transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (Can_Attack)
            {
                player_Movement.Can_Walk = false;
                CheckAtkInput();
            }
        }

        if (chargeTime > 0 && Is_charge == false)
        {
            Primary_Attack();
            //Is_charge = false;
            //player_Movement.Can_Walk = true;
            AfterPriAttack();

        }
        // else
        // {
        //     player_Movement.Can_Walk = true;
        // }





        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Right click");
        }

    }






    void CheckAtkInput()
    {
        if (Is_reloadScript == false)
        {
            if (Is_charge && Is_priChargeCD == false)
            {
                charging();
                //player_Movement.Can_Walk = false;
                // if (Is_charge == false)
                // {


                // }
            }
        }
        else if (Is_reloadScript == true)
        {
            Debug.Log("Reload??");
            chargeTime = 0;
            //Is_charge = false;
            player_Movement.Invoke("EnableCanMove", 0.5f);
            AfterPriAttack();
            Is_reloadScript = false;
        }

    }

    void AfterPriAttack()
    {
        Is_priChargeCD = true;
        Invoke(nameof(priChargeCD), 1.5f - attackSpd);
        pointerAttack.SetActive(false);
        player_Movement.Can_Walk = true;
    }

    void InitialPointer()
    {
        pointerAttack = Instantiate(pointerPrefab,
                                    transform.position,
                                    Quaternion.identity,
                                    transform);
        pointerAttack.SetActive(false);
    }
    void charging()
    {
        pointerAttack.SetActive(true);
        pointerAttack.GetComponent<Rigidbody2D>().rotation = angle - 90f;
        pointerAttack.transform.position = transform.position;
        if (chargeTime < maxCharge)
        {
            chargeTime += Time.deltaTime * chargeSpeed;
            player_Mana.AddMana(0.03f);
        }
        else
        {
            Primary_Attack();
            AfterPriAttack();
        }
    }
    void releaseChargeAttack()
    {
        CheckChargeState();
        SetChargeState();
        GameObject magicBall = Instantiate_Pri_magicBall();
        SetAngle(magicBall);

    }
    void CheckChargeState()
    {
        if (chargeTime > maxCharge)
        {
            chargeTime = maxCharge;
        }
        if (chargeTime < minCharge)
        {
            chargeTime = minCharge;
        }
    }
    void SetChargeState()
    {
        if (chargeTime < 0.5f)
        {
            chargeState = 1;
        }
        else if (chargeTime >= 0.5f && chargeTime < 1.5f)
        {
            chargeState = 2;
        }
        else if (chargeTime >= 1.5 && chargeTime <= 2f)
        {
            chargeState = 3;
        }
    }
    public GameObject Instantiate_Pri_magicBall()
    {
        GameObject magicBall = Instantiate(priMagicBall, transform.position, transform.rotation);
        Pri_magicBall pri_MagicBall = magicBall.GetComponent<Pri_magicBall>();
        magicBall.transform.localScale += new Vector3(0f, Mathf.Pow(2f, chargeTime), 0f);
        float sizeMultipler = chargeState;
        pri_MagicBall.SetDmg(0.3f * sizeMultipler * sizeMultipler * pri_MagicBall.GetDmg());
        pri_MagicBall.penetrateCount = chargeState;
        return magicBall;
    }
    public void SetAngle(GameObject magicBall)
    {
        //Move Pri_magicBall
        Rigidbody2D rbBall = magicBall.GetComponent<Rigidbody2D>();
        Pri_magicBall pri_MagicBall = magicBall.GetComponent<Pri_magicBall>();
        if (direction == Vector2.zero)
        {
            direction = Vector2.up;
            angle = 90f;
        }
        rbBall.rotation = angle;
        rbBall.AddForce(direction.normalized * pri_MagicBall.moveSpd, ForceMode2D.Impulse);
    }
    void Primary_Attack()
    {
        releaseChargeAttack();
        chargeTime = 0;
    }
    void priChargeCD()
    {
        this.Is_priChargeCD = false;
    }
    // void OnEnable(){
    //     Is_reloadScript =false;
    // }



}
