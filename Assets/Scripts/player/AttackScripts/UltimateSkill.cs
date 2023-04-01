using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class UltimateSkill : Ability
{
    public float increaseAtkSpd;
    public int increasePenetrateCount;

    // Update is called once per frame
    void Update()
    {

    }
    public override void Activate(GameObject parent)
    {


    }

    public override void BeginCooldown(GameObject parent)
    {
        GameObject Player = GameObject.FindWithTag("Player");
        parryGauge ParryGauge = Player.GetComponentInChildren<parryGauge>();
        Debug.Log(ParryGauge);
        int count = ParryGauge.gaugeCount;
        for (int i = 0; i <count ; i++)
        {
            ParryGauge.DeactiveGauge();
        }
    }
}
