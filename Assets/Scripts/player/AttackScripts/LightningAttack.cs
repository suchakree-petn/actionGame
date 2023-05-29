using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningAttack : MonoBehaviour
{
    [SerializeField] Weapon lighningWeapon = new Weapon(10f, 400f);
    [SerializeField] LightningStrike lightningStrike;
    [SerializeField] float hit_cd = 0;
    void Start()
    {
        hit_cd = lightningStrike.active_time;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && (!other.CompareTag("Player")))
        {
            ScreenShake.Shake();
            damageable.DamageReceive(lighningWeapon.dmg);
            damageable.knockBack(gameObject, lighningWeapon.knockBackRange);
            StartCoroutine(IEnum.IFrame(GetComponent<Collider2D>(), other, hit_cd));
        }
    }
}
