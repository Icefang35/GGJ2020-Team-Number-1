using System.Collections.Generic;
using Toolbox;
using UnityEngine;

public class StepSon : MonoBehaviour
{
    public Transform path;
    public Transform model;

    Movement3D movement;
    Arrive3D arrive;
    Rigidbody rb;

    int targetIndex = 0;
    Transform target;

    void Start()
    {
        movement = GetComponent<Movement3D>();
        arrive = GetComponent<Arrive3D>();
        rb = GetComponent<Rigidbody>();

        targetIndex = 0;
        target = path.GetChild(0);
    }

    void FixedUpdate()
    {
        movement.steering = arrive.GetSteering(target.position);

        if (!movement.steering.isMoving)
        {
            targetIndex++;
            targetIndex %= path.childCount;
            target = path.GetChild(targetIndex);
        }

        movement.LookWhereYoureGoing(model);
    }
}
