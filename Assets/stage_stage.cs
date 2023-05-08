using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class stage_stage : MonoBehaviour
{
    public int state;
    public Pri_magicBall pri_magicBall;
    public Player Player;
    public GameObject Skeleton;
    public TMP_Text fight_time_txt;
    public float fight_time;
    public float fight_time_temp;

    void Start()
    {
        state = 0;
        //StartCoroutine(wait(wait_Time));
        Player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {

        switch (state)
        {
            case 0:
                Skeleton.GetComponent<EnemyState>().animator.enabled = false;
                EnableSlection();
                break;
            case 1:
                //Debug.Log("State: 1");
                ShowTime();
                EnablePlayerControl();
                if (Skeleton != null)
                {
                    Animator animator = Skeleton.GetComponent<EnemyState>().animator;
                    animator.enabled = true;
                }
                DisableSlection();
                pri_magicBall.moveSpd = 15f;
                pri_magicBall.selfDestructTime = 20f;
                break;
            case 2:
                //Debug.Log("State: 2");
                Time.timeScale = 0;
                DisablePlayerControl();
                EnableSlection();
                break;
        }
    }
    public void ShowTime()
    {
        fight_time_txt.text = fight_time_temp.ToString("0.00");
        fight_time_temp -= Time.deltaTime;
        if (fight_time_temp <= 0f)
        {
            fight_time_txt.text = "0.00";
            state = 2;
        }
    }
    void DisablePlayerControl()
    {
        Player.DisableHP_Mana();
        Player.DisableParryGauge();
        Player.DisableJoyStick();
        Player.DisableSkill();
    }
    void EnablePlayerControl()
    {
        Player.EnableJoyStick();
        Player.EnableParryGauge();
        Player.EnableHP_Mana();
        Player.EnableSkill();
    }
    public Button applySelect_Button;
    public GameObject platforms;

    public void EnableSlection()
    {
        EnableCollider();
        DisablePlayerControl();
        applySelect_Button.gameObject.SetActive(true);
    }
    public void DisableSlection()
    {
        DisableCollider();
        EnablePlayerControl();
        applySelect_Button.gameObject.SetActive(false);

    }
    void EnableCollider()
    {
        foreach (Transform child in platforms.transform)
        {
            child.GetComponent<Collider2D>().enabled = true;
        }
    }
    void DisableCollider()
    {
        foreach (Transform child in platforms.transform)
        {
            child.GetComponent<Collider2D>().enabled = false;
        }
    }
    
}
