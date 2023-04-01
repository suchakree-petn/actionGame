using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu]
public class FireBlast : Ability
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject barrierPrefab;
    [SerializeField] GameObject fireRingPrefab;
    public GameObject barrier;
    public bool Is_AttackedWhileParry = false;

    public override void Activate(GameObject parent)
    {

        InstantiateBarrier(parent);
        Destroy(barrier, this.active_time);
        parent.GetComponent<AbilityHolder>().button.interactable =false;
    }


    public void InstantiateBarrier(GameObject parent)
    {
        barrier = Instantiate(barrierPrefab,
                            new Vector3(parent.transform.position.x,
                                        parent.transform.position.y - 0.04f,
                                        parent.transform.position.z),
                            Quaternion.identity,
                            parent.transform);
        Is_Parry = true;

    }
    public void InstantiateFireRing()
    {
        Player = GameObject.FindWithTag("Player");
        parryGauge ParryGauge = Player.GetComponentInChildren<parryGauge>();
        ParryGauge.ActiveGauge();
        ParryGauge.OnSuccesParry();
        
        AbilityHolder abilityHolder = Player.GetComponentInChildren<AbilityHolder>();
        abilityHolder.button.interactable = false;
        abilityHolder.Is_AttackedWhileParry = true;
        Player.GetComponent<Player>().Do_Immortal(1);
        GameObject fireRingInstance = Instantiate(
                    fireRingPrefab,
                    Player.transform.position,
                    Quaternion.identity
                   );
        fireRingInstance.transform.localScale += new Vector3(6f, 6f, 0);
        Destroy(fireRingInstance, active_time);
    }

}
