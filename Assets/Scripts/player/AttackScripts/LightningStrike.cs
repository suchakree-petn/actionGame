using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LightningStrike : Ability
{
    [SerializeField] private GameObject LightningPrefab;
    [SerializeField] private int scaleCount;
    [SerializeField] private Vector3 localScale = new Vector3(3, 3, 0);

    public override void ActivateRepeat(List<Vector2> targetPos)
    {
        ScreenShake.Shake();
        InstantiateLightningArea(targetPos);

    }
    private void InstantiateLightningArea(List<Vector2> targetPos)
    {
        GameObject lightningArea = Instantiate(LightningPrefab,
                                            (Vector3)targetPos[scaleCount],
                                            Quaternion.identity
                                            );
        if (repeat > 0)
        {
            localScale += new Vector3(scaleCount, scaleCount, 0);
            scaleCount++;
        }
        lightningArea.transform.localScale = localScale;
        Destroy(lightningArea, 1f);
        if (scaleCount == repeat)
        {
            scaleCount = 0;
            localScale = new Vector3(3, 3, 0);
        }

    }

}
