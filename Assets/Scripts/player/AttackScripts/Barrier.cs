using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] FireBlast fireBlast;
    void Start()
    {
        gameObject.name = "Barrier";
    }
    void Update()
    {
        if (fireBlast.Is_AttackedWhileParry)
        {
            Debug.Log("Destroy");
            Destroy(gameObject);
        }
    }


    void OnDestroy()
    {
        fireBlast.Is_Parry = false;

    }

}
