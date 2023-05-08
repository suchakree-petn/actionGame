using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : StateMachineBehaviour
{
    public Transform target;
    public float moveSpeed;
    public float attackRange;
    public Transform thisPos;
    public stage_stage stage_Stage;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        target = GameObject.FindWithTag("Player").transform;
        thisPos = animator.transform.parent;
        stage_Stage = GameObject.FindWithTag("GameController").GetComponentInChildren<stage_stage>();
        if (stage_Stage != null)
        {
            attackRange *= 10f;
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisPos.position = Vector2.MoveTowards(thisPos.position, target.position, moveSpeed * Time.deltaTime);
        if (animator.transform.parent.position.x <= target.position.x)
        {
            animator.GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            animator.GetComponent<SpriteRenderer>().flipX = true;
        }
        check_atk_range(animator);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
    private void check_atk_range(Animator animator)
    {
        if (Vector2.Distance(thisPos.position, target.position) <= attackRange)
        {
            animator.SetTrigger("PrepAttack");
        }
    }
}
