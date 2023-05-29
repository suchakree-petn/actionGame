using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonAnim : MonoBehaviour
{
    public Sprite buttonPressed;
    
    public void SwitchSprite()
    {
        GetComponent<Image>().sprite = buttonPressed;
    }
}
