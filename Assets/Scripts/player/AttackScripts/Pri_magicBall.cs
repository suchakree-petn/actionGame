using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Pri_magicBall : MonoBehaviour
{
    public float moveSpd = 1f;
    [SerializeField] private float dmg = 20f;
    public float knockBackRange;
    [SerializeField] private float selfDestructTime = 2f;
    public float hit_cd = 1f;
    public int penetrateCount;
    public GameObject player;


    void Awake()
    {

        //rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Destroy(gameObject, selfDestructTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        CheckPenetrateCount();
        if (penetrateCount > 0)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null && (!other.CompareTag("Player")))
            {
                damageable.DamageReceive(this.dmg);
                damageable.knockBack(this.gameObject, knockBackRange);
                StartCoroutine(IEnum.IFrame(GetComponent<Collider2D>(), other, hit_cd));
                penetrateCount--;
            }
            CheckPenetrateCount();
        }
    }
    void CheckPenetrateCount()
    {
        if (penetrateCount <= 0)
        {
            
            Destroy(gameObject);
        }
    }

    public void SetMoveSpd(float moveSpd)
    {
        this.moveSpd = moveSpd;
    }
    public void SetDmg(float dmg)
    {
        this.dmg = dmg;
    }
    public float GetDmg()
    {
        return this.dmg;
    }
    public void SetSelfDestructTime(float selfDestructTime)
    {
        this.selfDestructTime = selfDestructTime;
    }


}
