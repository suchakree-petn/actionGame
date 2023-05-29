using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class ScreenShake
{
    public static void Shake()
    {
        Animator camAnim = Camera.main.GetComponent<Animator>();
        camAnim.SetTrigger("Shake");
    }
}
