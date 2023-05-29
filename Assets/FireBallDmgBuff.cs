using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FireBallDmgBuff : MonoBehaviour
{
    public int price;
    public TMP_Text text;
    public Pri_magicBall pri_MagicBall;
    public void OnSelected()
    {
        int Coin = GameObject.FindWithTag("GameController").GetComponent<GameController>().Coin;
        if (Coin >= price)
        {
            GameObject.FindWithTag("GameController").GetComponent<GameController>().Coin -= price;
            GameObject.FindWithTag("GameController").GetComponent<GameController>().UpdateCoin();
            pri_MagicBall.SetDmg(pri_MagicBall.GetDmg() + 12f);
            CloseBuff();
        }
        else
        {
            text.color = new Color(255f, 255f, 0f, 255f);
        }
    }
    public void CloseBuff()
    {
        transform.parent.gameObject.SetActive(false);
    }
}
