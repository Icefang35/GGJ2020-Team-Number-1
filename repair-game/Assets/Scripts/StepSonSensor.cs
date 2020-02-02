using UnityEngine;

public class StepSonSensor : MonoBehaviour
{
    ParentItem parentItem;

    void Start()
    {
        parentItem = GetComponentInParent<ParentItem>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "StepSon" && parentItem.IsComplete())
        {
            parentItem.Explode();
        }
    }
}
