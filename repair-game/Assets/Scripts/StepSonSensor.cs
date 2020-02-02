using UnityEngine;
using System.Collections;

public class StepSonSensor : MonoBehaviour
{
    ParentItem parentItem;
    public float waitTime = 3f;

    void Start()
    {
        parentItem = GetComponentInParent<ParentItem>();
    }

    IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.name == "StepSon" && parentItem.IsComplete())
        {
            StepSon stepSon = other.GetComponent<StepSon>();
            stepSon.stareTarget = transform;

            yield return new WaitForSeconds(waitTime);
            
            parentItem.Explode();
            stepSon.stareTarget = null;
        }
    }
}
