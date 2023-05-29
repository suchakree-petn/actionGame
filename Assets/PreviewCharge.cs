using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCharge : MonoBehaviour
{
    public player_attack player_Attack;
    public int state;
    private GameObject previewCharge;
    void Awake()
    {
        player_Attack = GameObject.FindWithTag("Player").GetComponent<player_attack>();
    }
    void OnEnable()
    {
        player_Attack.CheckChargeState();
        player_Attack.SetChargeState();
        state = player_Attack.chargeState;
        previewCharge = player_Attack.Instantiate_Pri_magicBall();
        previewCharge.GetComponent<Collider2D>().enabled = false;
        previewCharge.GetComponent<Pri_magicBall>().enabled = false;
    }
    void OnDisable()
    {
        state = 0;
        if (previewCharge != null)
        {
            Destroy(previewCharge);
        }
    }
    void Update()
    {
        player_Attack.CheckChargeState();
        player_Attack.SetChargeState();
        state = player_Attack.chargeState;
        float size = Mathf.Pow(2f, player_Attack.chargeTime + 1f);
        previewCharge.transform.localScale = new Vector3(size, size, size);
        previewCharge.transform.position = transform.position;
        previewCharge.GetComponent<Rigidbody2D>().rotation = player_Attack.angle;
        previewCharge.GetComponent<Animator>().SetInteger("State", state);

    }
}
