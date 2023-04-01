
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack_1 : MonoBehaviour
{

    public float dmg = 21f;
    public float atk_range;
    public float atk_Aoe;
    public float knockBackRange;
    public float hit_cd = 1f;
    public float thrustAttackSpeed = 10f;
    public Vector2 direction;
    public GameObject enemy_attack_1_prefab;



    //[SerializeField] enemy_attack_1 enemy_Attack_1;
    [SerializeField] FireBlast fireBlast;
    public Enemy enemy;
    public float stunTime = 2f;
    public AudioSource afterAttackAud;
    public AudioSource prepAttackAud;

    
    public void GetDirTarget()
    {
        direction = enemy.player.transform.position - transform.position;
    }
    public void Attack_1()
    {
        afterAttackAud.Play();
        enemy.rbEnemy.AddForce(direction.normalized * thrustAttackSpeed, ForceMode2D.Impulse);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, atk_Aoe);
    }
    public void DoCoroutine_DelayAttack(Animator animator)
    {
        StartCoroutine(DelayAttack(animator));
    }
    IEnumerator DelayAttack(Animator animator)
    {
        animator.SetBool("Can_attack", false);

        yield return new WaitForSeconds(2f);
        enemy.rbEnemy.velocity = Vector2.zero;
        animator.SetBool("Can_attack", true);
        animator.SetBool("Is_attack", false);
    }
    public void DoCoroutine_IFrame(Collider2D attackSource, Collider2D target, float hit_cd)
    {
        StartCoroutine(IEnum.IFrame(attackSource, target, hit_cd));

    }
    public void PrepAttackAud(){
        prepAttackAud.Play();
    }

}
