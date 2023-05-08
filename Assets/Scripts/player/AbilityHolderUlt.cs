using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolderUlt : MonoBehaviour
{
    public Ability ability;
    private float cd_time;
    private float active_time;
    public float in_active_time;

    [SerializeField] private KeyCode key;
    [SerializeField] private bool Is_performed;
    public int count = 1;
    public float angle = 0f;
    public enum AbilityState
    {
        ready,
        active,
        cd
    }
    public AbilityState state = AbilityState.ready;

    void Start()
    {
        //player.playerInputActions.Player_Attack.Skill01.performed += context => UseSkill();
    }

    void Update()
    {
       
        switch (state)
        {
            case AbilityState.ready:
                if (Is_performed)
                {
                    ability.Activate(gameObject);
                    state = AbilityState.active;
                    active_time = ability.active_time;
                    in_active_time = ability.in_active_time;
                }
                break;
            case AbilityState.active:
                if (active_time > 0)
                {
                    if (in_active_time == ability.in_active_time)
                    {
                        StartCoroutine(UltActive(gameObject, in_active_time));
                        in_active_time -= Time.deltaTime;
                    }
                    else
                    {
                        in_active_time -= Time.deltaTime;
                        if (in_active_time <= 0)
                        {
                            in_active_time = ability.in_active_time;
                        }
                    }

                    active_time -= Time.deltaTime;
                }
                else
                {
                    ability.BeginCooldown(gameObject);
                    state = AbilityState.cd;
                    cd_time = ability.cd_time;
                }
                break;
            case AbilityState.cd:
                if (cd_time > 0)
                {
                    cd_time -= Time.deltaTime;
                }
                else
                {
                    Is_performed = false;
                    state = AbilityState.ready;
                }
                break;
        }
    }
    public void Is_Performed()
    {
        Is_performed = true;
    }
    public IEnumerator UltActive(GameObject parent, float sec)
    {
        player_attack player_Attack = parent.GetComponentInParent<player_attack>();
        //player_Attack.attackSpd += ability.increaseAtkSpd;
        for (int i = 0; i < 4; i++)
        {
            GameObject magicBall = player_Attack.Instantiate_Pri_magicBall();
            magicBall.transform.localScale += new Vector3(0, 1, 0);
            SetAngleUlt(magicBall);
        }
        count = 1;
        angle = 0f;
        yield return new WaitForSeconds(sec);
    }
    void SetAngleUlt(GameObject magicBall)
    {
        Rigidbody2D rbBall = magicBall.GetComponent<Rigidbody2D>();
        Pri_magicBall pri_MagicBall = magicBall.GetComponent<Pri_magicBall>();

        rbBall.rotation = angle;
        switch (count)
        {
            case 1:
                rbBall.AddForce(Vector2.left.normalized * pri_MagicBall.moveSpd, ForceMode2D.Impulse);
                angle += 90;
                count++;
                break;
            case 2:
                rbBall.AddForce(Vector2.up.normalized * pri_MagicBall.moveSpd, ForceMode2D.Impulse);
                angle += 90;
                count++;
                break;
            case 3:
                rbBall.AddForce(Vector2.right.normalized * pri_MagicBall.moveSpd, ForceMode2D.Impulse);
                angle += 90;
                count++;
                break;
            case 4:
                rbBall.AddForce(Vector2.down.normalized * pri_MagicBall.moveSpd, ForceMode2D.Impulse);
                angle += 90;
                count++;
                break;
        }

    }
}
