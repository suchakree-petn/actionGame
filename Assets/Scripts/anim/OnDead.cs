using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDead : StateMachineBehaviour
{
    public EnemyState enemyState;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyState = animator.transform.parent.GetComponent<EnemyState>();
        if (enemyState.gameController != null)
        {
            enemyState.GetComponent<Collider2D>().enabled = false;
            Destroy(enemyState.Enemy_Hp);
            Debug.Log("Now count: " + enemyState.gameController.EnemyList.Count);
            enemyState.gameController.AddCoin(5);
            enemyState.gameController.AddObjectiveAmount(1);
        }
        else
        {
            GameObject.FindWithTag("GameController").GetComponent<GameControllerSpecialStage>().On_Skeleton_Die();
        }


    }
    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemyState.gameController != null)
        {
            enemyState.gameController.EnemyList.Remove(enemyState.gameObject);
            Destroy(enemyState.gameObject);
        }
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
