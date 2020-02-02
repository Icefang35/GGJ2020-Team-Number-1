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
        if (other.name == "StepSon")
        {
            StepSon stepSon = other.GetComponent<StepSon>();
            StartCoroutine(stepSon.BreakThings(parentItem));
        }
    }
}
