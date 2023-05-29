using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LightningStrikeCDBuff : MonoBehaviour
{
    public int price;
    public TMP_Text text;
    public AbilityHolderRepeat abilityHolderRepeat;
    public void OnSelected()
    {
        int Coin = GameObject.FindWithTag("GameController").GetComponent<GameController>().Coin;
        if (Coin >= price)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().Coin -= price;
            GameObject.FindWithTag("GameController").GetComponent<GameController>().UpdateCoin();
            abilityHolderRepeat.ability.cd_time-=2;
            if (abilityHolderRepeat.ability.cd_time < 1)
            {
                abilityHolderRepeat.ability.cd_time = 1;
            }
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
