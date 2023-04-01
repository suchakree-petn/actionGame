using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float cam_speed = 2f;
    //public float y_offset = 1f;
    [SerializeField] private Transform target;
    void Start()
    {

        target = GameObject.Find("PlayerGroup/player").transform;
    }
    void FixedUpdate()
    {
        Vector3 new_Pos = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, new_Pos, cam_speed * Time.deltaTime);
        //transform.position = new_Pos;
    }
}
