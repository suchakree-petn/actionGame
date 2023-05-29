using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ManaRegenBuff : MonoBehaviour
{
    public int price;
    public TMP_Text text;
    public Player_Mana player_Mana;
    public void OnSelected()
    {
        int Coin = GameObject.FindWithTag("GameController").GetComponent<GameController>().Coin;
        if (Coin >= price)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().Coin -= price;
            GameObject.FindWithTag("GameController").GetComponent<GameController>().UpdateCoin();
            player_Mana.manaRegen += 0.01f;
            CloseBuff();
        }
        else
        {
            text.color = new Color(255f, 255f, 0f, 255f);
        }
    }
    void CloseBuff()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
