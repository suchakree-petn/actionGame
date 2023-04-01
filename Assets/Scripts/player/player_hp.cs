using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_hp : Player
{
    public Slider hp_body;

   
    void Start()
    {
        hp_body.maxValue = player_max_hp;
        hp_body.value = player_max_hp;
    }

}
