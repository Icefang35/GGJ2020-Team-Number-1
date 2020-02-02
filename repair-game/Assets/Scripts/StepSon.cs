using System.Collections.Generic;
using Toolbox;
using UnityEngine;

public class StepSon : MonoBehaviour
{
    public Transform path;
    public Transform model;
    public Transform stareTarget;

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
        if (CanvasManager.isPaused)
        {
            movement.steering = Steering3D.Stop;
        }
        else if (stareTarget)
        {
            movement.steering = Steering3D.Stop;

            Vector3 direction = (stareTarget.position - transform.position).normalized;
            movement.LookAtDirection(model, direction);
        }
        else
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
}
