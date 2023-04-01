using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    public float dmg;
    public float knockBackRange;

    public Weapon(float dmg,float knockBackRange){
        this.dmg = dmg;
        this.knockBackRange = knockBackRange;
    }
}
