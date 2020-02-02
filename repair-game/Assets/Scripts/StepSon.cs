using Toolbox;
using UnityEngine;

public class StepSon : MonoBehaviour
{
    public Transform target;

    Movement3D movement;
    Arrive3D arrive;

    void Start()
    {
        movement = GetComponent<Movement3D>();
        arrive = GetComponent<Arrive3D>();
    }

    void FixedUpdate()
    {
        movement.steering = arrive.GetSteering(target.position);
    }
}
