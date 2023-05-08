using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour, IDamageable
{
    public Rigidbody2D rbEnemy;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject Enemy_Hp;
    public enemy_attack_1 enemy_Attack_1;
    public float hp = 100;
    public Player player;
    //[SerializeField] private bool Is_KnockBack;
    [SerializeField] Vector3 Player_Pos;
    //[SerializeField] private bool Is_Die = false;
    [SerializeField] private GameObject canvas;
    public GameController gameController;
    public AudioSource audioSource;
    void Awake()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

    }
    void Start()
    {
    }
    void Update()
    {
        Player_Pos = player.transform.position;
        if (Enemy_Hp != null)
        {
            Enemy_Hp.SetActive(true);
            Enemy_Hp.transform.position = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z));
        }
    }
    
    public void DamageReceive(float dmg)
    {
        animator.SetTrigger("Hit");
        hp -= dmg;
        audioSource.Play();
        animator.SetBool("Is_attack", false);
        enemy_Attack_1.DoCoroutine_DelayAttack(animator);
        SetHp();
    }
    void SetHp()
    {
        Enemy_Hp.GetComponent<Slider>().value = hp;
        if (hp <= 0)
        {
            OnDie();
        }
    }
    private void OnDie()
    {
        animator.SetBool("Dead",true);
    }
    public void knockBack(GameObject attacker, float knockBackRange)
    {
        //Is_KnockBack = true;
        Vector3 attacker_Pos = Player_Pos;
        Vector3 target_Pos = transform.position;
        Vector2 direction = target_Pos - attacker_Pos;
        rbEnemy.velocity = Vector2.zero;
        rbEnemy.AddForce(direction.normalized * knockBackRange, ForceMode2D.Force);
        Invoke("AfterKnockBack", 0.5f);
        StartCoroutine(IEnum.KBDelay(gameObject));

    }
    void AfterKnockBack()
    {
        //animator.SetBool("Can_attack", true);
        //Is_KnockBack = false;
    }
    public void check_atk_range(float currentDistance, float atk_range)
    {
        if (currentDistance <= atk_range && animator.GetBool("Is_attack") == false && animator.GetBool("Can_attack")==true)
        {
            animator.SetBool("Is_attack", true);
            animator.SetTrigger("PrepAttack");
        }

    }
    public IEnumerator TimeDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        animator.SetBool("Is_attack", false);
    }
}
