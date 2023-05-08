using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Attack : StateMachineBehaviour
{
    public GameObject throwingBone;
    public float throwSpd;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject bone = Instantiate(throwingBone, animator.transform.position, Quaternion.identity);
        Vector3 targetPos = GameObject.FindWithTag("Player").transform.position;
        Vector2 dir = targetPos - animator.transform.position;
        Rigidbody2D boneRb = bone.GetComponent<Rigidbody2D>();
        boneRb.AddForce(dir.normalized * throwSpd, ForceMode2D.Impulse);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

}
