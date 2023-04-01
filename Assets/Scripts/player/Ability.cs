using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ability : ScriptableObject
{
    public new string name;
    public float cd_time;
    public float active_time;
    public int repeat;
    public bool Is_Parry;
    public float repeat_time;
    public float in_active_time;
    public float delayButton;

    
    public virtual void Activate(GameObject parent) { }
    public virtual void ActivateRepeat(List<Vector2> targerPos) { }
    //public virtual void ActiveSkill(){}
    public virtual void BeginCooldown(GameObject parent) { }
}
