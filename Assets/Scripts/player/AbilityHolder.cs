using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AbilityHolder : MonoBehaviour
{
    public Ability ability;
    private float cd_time;
    private float active_time;
    private float delayButton;

    [SerializeField] private KeyCode key;
    public bool Is_performed;
    public bool Is_AttackedWhileParry;
    public Button button;
    public AudioSource audioSource;

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
                    if (button.interactable == true)
                    {
                        ability.Activate(gameObject);
                        Is_performed = false;
                        StartCoroutine(ActiveButton());
                    }

                }
                if (Is_AttackedWhileParry)
                {
                    Is_AttackedWhileParry = false;
                    state = AbilityState.active;
                    audioSource.Play();
                    active_time = ability.active_time;
                }

                break;
            case AbilityState.active:
                if (active_time > 0)
                {
                    button.interactable = false;
                    active_time -= Time.deltaTime;
                }
                else
                {
                    //ability.BeginCooldown(gameObject);
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
                    state = AbilityState.ready;
                    button.interactable = true;
                }
                break;
        }
    }
    public void Is_Performed()
    {
        Is_performed = true;
    }
    IEnumerator ActiveButton()
    {
        yield return new WaitForSeconds(1f);
        button.interactable = true;
    }
}
