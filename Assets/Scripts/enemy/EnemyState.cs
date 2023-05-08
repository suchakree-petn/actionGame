using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyState : MonoBehaviour, IDamageable
{
    public Rigidbody2D rbEnemy;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public GameObject Enemy_Hp;
    public Skeleton_Attack skeleton_Attack;
    public float hp;
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
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

    }
    void Start()
    {
        Enemy_Hp.GetComponent<Slider>().maxValue = hp;
        Enemy_Hp.GetComponent<Slider>().value = hp;
    }
    void Update()
    {
        Player_Pos = player.transform.position;
        if (Enemy_Hp != null)
        {
            Enemy_Hp.SetActive(true);
            Vector3 skeletonPos = transform.position;
            Enemy_Hp.transform.position = Camera.main.WorldToScreenPoint(new Vector3(skeletonPos.x, skeletonPos.y + 0.8f, skeletonPos.z));
        }
    }

    public void DamageReceive(float dmg)
    {

        hp -= dmg;
        audioSource.Play();
        animator.SetBool("Is_attack", false);
        animator.SetTrigger("Hit");
        //skeleton_Attack.DoCoroutine_DelayAttack(animator);
        SetHp();
    }
    public void SetHp()
    {
        Enemy_Hp.GetComponent<Slider>().value = hp;
        if (hp <= 0)
        {
            //Is_Die = true;
            OnDie();
        }
    }
    private void OnDie()
    {
        animator.SetBool("Dead", true);

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
    // public void check_atk_range(float currentDistance, float atk_range)
    // {
    //     if (currentDistance <= atk_range && animator.GetBool("Is_attack") == false && animator.GetBool("Can_attack")==true)
    //     {
    //         animator.SetBool("Is_attack", true);
    //         animator.SetTrigger("PrepAttack");
    //     }

    // }
    public IEnumerator TimeDelay(float sec)
    {
        yield return new WaitForSeconds(sec);
        animator.SetBool("Is_attack", false);
    }
}
