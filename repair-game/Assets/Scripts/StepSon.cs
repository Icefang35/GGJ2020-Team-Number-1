using Toolbox;
using UnityEngine;

public class StepSon : MonoBehaviour
{
    public Transform path;

    Movement3D movement;
    Arrive3D arrive;

    int targetIndex = 0;
    Transform target;

    void Start()
    {
        movement = GetComponent<Movement3D>();
        arrive = GetComponent<Arrive3D>();

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
    }
}
