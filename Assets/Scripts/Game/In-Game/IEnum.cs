using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IEnum
{
    public static IEnumerator KBDelay(GameObject target)
    {
        yield return new WaitForSeconds(0.2f);
        target.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    
    public static IEnumerator IFrame(Collider2D attackSource, Collider2D target, float hit_cd)
    {
        if (attackSource != null && target != null)
        {
            Physics2D.IgnoreCollision(attackSource, target, true);

            yield return new WaitForSeconds(hit_cd);
            if (attackSource != null && target != null)
            {
                Physics2D.IgnoreCollision(attackSource, target, false);
            }
        }

    }

}
