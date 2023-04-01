
using UnityEngine;

public interface IDamageable
{
    void DamageReceive(float dmg);
    void knockBack(GameObject attacker,float knockBackRange);
}
