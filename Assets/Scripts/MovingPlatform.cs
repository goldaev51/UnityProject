using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    bool going_to_a = false;
    public float MoveSpeed = 3f;
    public float time_to_wait;
    public float time_to_pause = 2f;

    public Vector3 moveBy;
    Vector3 pointA;
    Vector3 pointB;
    // Use this for initialization
    void Start()
    {
        this.pointA = this.transform.position;
        this.pointB = this.pointA + moveBy;
        time_to_wait = time_to_pause;
    }

    // Update is called once per frame
    void Update()
    {
        time_to_wait -= Time.deltaTime;
        if (time_to_wait <= 0)
        {

            Vector3 my_pos = this.transform.position;
            Vector3 target = (going_to_a) ? this.pointA : this.pointB;

            Vector3 destination = target - my_pos;
            destination.z = 0;
            destination.Normalize();
            this.transform.position += destination * MoveSpeed * Time.deltaTime;
            if (isArrived(my_pos, target))
            {
                going_to_a = !going_to_a;//return
                time_to_wait = time_to_pause;
            }
        }
    }
    bool isArrived(Vector3 pos, Vector3 target)
    {
        pos.z = 0;
        target.z = 0;

        return (Vector3.Distance(pos, target) < 0.02f);
    }
}Ы