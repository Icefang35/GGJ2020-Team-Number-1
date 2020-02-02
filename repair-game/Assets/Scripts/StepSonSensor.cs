using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Toolbox;

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
            other.GetComponent<StepSon>().enabled = false;
            other.GetComponent<Movement3D>().steering = Steering3D.Stop;
            yield return new WaitForSeconds(waitTime);
            parentItem.Explode();
            other.GetComponent<StepSon>().enabled = true;

        }
    }
}
