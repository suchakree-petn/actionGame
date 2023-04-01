using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireRingAttack : MonoBehaviour
{
    [SerializeField] Weapon fireRingWeapon = new Weapon(10f, 700f);
    [SerializeField] FireBlast fireBlast;
    [SerializeField] float hit_cd;
    void Start()
    {
        hit_cd = fireBlast.active_time;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && (!other.CompareTag("Player")))
        {
            damageable.DamageReceive(fireRingWeapon.dmg);
            damageable.knockBack(gameObject, fireRingWeapon.knockBackRange);
            StartCoroutine(IEnum.IFrame(GetComponent<Collider2D>(), other,hit_cd));
        }
    }
}
