using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LightningStrike : Ability
{
    [SerializeField] private GameObject LightningPrefab;
    [SerializeField] private int scaleCount;
    //[SerializeField] private SpriteRenderer lightningSprite;
    [SerializeField] private Color lightningColor;
    [SerializeField] private Vector3 localScale = new Vector3(3, 3, 0);





    public override void ActivateRepeat(List<Vector2> targetPos)
    {
        
        //Transform parentTransform = parent.transform;
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
            lightningColor = lightningArea.GetComponent<SpriteRenderer>().color;
            lightningColor.a = 1f - scaleCount / 5f;
            scaleCount++;
        }
        lightningArea.transform.localScale = localScale;
        lightningArea.GetComponent<SpriteRenderer>().color = lightningColor;

        //lightningArea.transform.localScale += new Vector3(scaleCount, scaleCount, 0);
        Destroy(lightningArea, this.active_time);

        if (scaleCount == repeat)
        {
            lightningColor.a = 255f;
            scaleCount = 0;
            localScale = new Vector3(3, 3, 0);
        }

    }

}
