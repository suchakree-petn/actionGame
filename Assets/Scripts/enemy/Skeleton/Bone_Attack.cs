using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bone_Attack : MonoBehaviour
{
    public FireBlast fireBlast;
    public float dmg;
    public float knockBackRange;
    public float hit_cd;
    void Start()
    {
        Destroy(gameObject, 3f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null && (!other.CompareTag("Enemy")))
        {
            
            if (other.CompareTag("Player"))
            {
                //Debug.Log("Player not parrying");
                Destroy(gameObject);
                damageable.DamageReceive(dmg);
                damageable.knockBack(gameObject, knockBackRange);
                StartCoroutine(IEnum.IFrame(this.GetComponent<Collider2D>(), other, hit_cd));
            }
        }
        if (other.name == "Barrier")
            {
                //Debug.Log("Player parrying");
                Destroy(gameObject);
                fireBlast.Is_Parry = false;
                fireBlast.InstantiateFireRing();
            }
    }
}
