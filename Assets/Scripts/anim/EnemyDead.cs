using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDead : StateMachineBehaviour
{
    Enemy enemy;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.GetComponent<enemy_movement>().enabled = false;
        animator.GetComponent<Collider2D>().enabled = false;
        enemy = animator.GetComponent<Enemy>();
        Destroy(enemy.Enemy_Hp);
        enemy.gameController.AddCoin(5);
        enemy.gameController.AddObjectiveAmount(1);
        Debug.Log("Now count: " + enemy.gameController.EnemyList.Count);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy.gameController.EnemyList.Remove(animator.gameObject);
        Destroy(animator.gameObject);

    }

}
