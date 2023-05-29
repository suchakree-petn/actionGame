using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class anim_attack_1 : StateMachineBehaviour
{
    [SerializeField] private Collider2D[] all_Collider;
    [SerializeField] enemy_attack_1 enemy_Attack_1;
    [SerializeField] FireBlast fireBlast;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy_Attack_1 = animator.GetComponent<enemy_attack_1>();
        animator.SetBool("Can_attack", false);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        all_Collider = Physics2D.OverlapCircleAll(animator.transform.position, enemy_Attack_1.atk_Aoe);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        foreach (Collider2D other in all_Collider)
        {
            if (other != null)
            {
                IDamageable damageable = other.GetComponent<IDamageable>();

                if (damageable != null && (!other.CompareTag("Enemy")))
                {
                    if (other.CompareTag("Player") && fireBlast.Is_Parry)
                    {
                        Debug.Log("Player parrying");

                        fireBlast.Is_Parry = false;
                        fireBlast.InstantiateFireRing();

                    }
                    if (!fireBlast.Is_Parry)
                    {
                        Debug.Log("Player not parrying");
                        damageable.DamageReceive(enemy_Attack_1.dmg);
                        damageable.knockBack(animator.gameObject, enemy_Attack_1.knockBackRange);
                        enemy_Attack_1.DoCoroutine_IFrame(animator.GetComponent<Collider2D>(), other, enemy_Attack_1.hit_cd);
                    }
                }
            }

        }
        List<Collider2D> list_allCollider = all_Collider.ToList();
        list_allCollider.Clear();
        all_Collider = list_allCollider.ToArray();
        enemy_Attack_1.enemy.rbEnemy.velocity = Vector2.zero;
        animator.SetBool("Is_attack", false);
        enemy_Attack_1.DoCoroutine_DelayAttack(animator);
    }


    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}

}
