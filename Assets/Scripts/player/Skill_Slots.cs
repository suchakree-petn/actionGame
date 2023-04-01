using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Skill_Slots : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private AbilityHolder abilityHolder_01;
    [SerializeField] private AbilityHolderRepeat abilityHolder_02;

    void Start()
    {
        player = GetComponentInParent<Player>();
    }
    public void UseSkill_01(InputAction.CallbackContext context)
    {
        if (context.performed)
        {

            if (abilityHolder_01.state == AbilityHolder.AbilityState.ready)
            {

                abilityHolder_01.state = AbilityHolder.AbilityState.active;
                abilityHolder_01.ability.Activate(GameObject.FindWithTag("Player"));
            }

        }
    }
    public void UseSkill_01()
    {
        if (abilityHolder_01.state == AbilityHolder.AbilityState.ready)
        {
            abilityHolder_01.ability.Activate(GameObject.FindWithTag("Player"));
        }
    }
    // public void UseSkill_02(InputAction.CallbackContext context)
    // {
    //     if (context.performed)
    //     {
    //         Debug.Log("User Skill 02");

    //         if (abilityHolder_02.state == AbilityHolderRepeat.AbilityState.ready)
    //         {
    //             abilityHolder_02.state = AbilityHolderRepeat.AbilityState.active;
    //         }

    //     }
    // }
}
