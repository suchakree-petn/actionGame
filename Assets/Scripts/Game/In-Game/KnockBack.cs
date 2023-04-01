using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    Rigidbody2D targetRB;
    public GameObject targetObj;
    public Animator animator;
    player_movement player_Movement;
    Player player;
    void Start()
    {
        targetObj = GameObject.FindWithTag("Player");
        player_Movement = targetObj.GetComponent<player_movement>();
        player = GetComponent<Player>();
        targetRB = targetObj.GetComponent<Rigidbody2D>();
        animator = targetObj.GetComponent<Animator>();

    }
    public void Knock<T>(T temp)
    {
        Vector3 attacker_Pos = transform.position;
        Vector3 target_Pos = targetObj.transform.position;
        Vector2 direction = target_Pos - attacker_Pos;
        if (temp is enemy_attack_1)
        {
            enemy_attack_1 attackerScript = (temp as enemy_attack_1);

            StartCoroutine(KBDelay());
            StartCoroutine(StunDelay(attackerScript.stunTime));
            targetRB.AddForce(direction.normalized * attackerScript.knockBackRange, ForceMode2D.Force);
        }

    }
    IEnumerator StunDelay(float stunTime)
    {
        player.Is_stun = true;

        yield return new WaitForSeconds(stunTime);

        player.Is_stun = false;
    }
    IEnumerator KBDelay()
    {
        yield return new WaitForSeconds(0.2f);
        targetRB.velocity = Vector2.zero;
    }
}
