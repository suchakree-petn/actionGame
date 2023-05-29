using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Mana : MonoBehaviour
{
    public Slider mana_body;
    public float max_mana;
    public float mana;
    public float manaRegen;

    void Start()
    {
        mana_body.maxValue = max_mana;
        mana_body.value = mana;
    }
    void Update()
    {
        if (mana >= 100f)
        {
            mana = 100;
        }
        else
        {
            mana += manaRegen;
            UpdatePlayerMana();
        }
    }
    void UpdatePlayerMana()
    {
        mana_body.value = mana;
    }
    public void AddMana(float value)
    {
        mana += value;
        UpdatePlayerMana();
    }

}
