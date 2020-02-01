using Toolbox;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform itemHolder;

    [Tooltip("Percent of the way to the target it should follow."), Range(0.001f, 1f)]
    public float followPercent = 0.1f;
    [Tooltip("Time it takes to interpolate follow percent of the way to the target."), Range(0.001f, 1f)]
    public float followTime = 1f / 60f;

    private Rigidbody heldItem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {
                if (hit.transform.tag == "Holdable")
                {
                    heldItem = hit.transform.GetComponent<Rigidbody>();
                    heldItem.useGravity = false;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && heldItem)
        {
            heldItem.useGravity = true;
            heldItem = null;
        }

        if (heldItem)
        {
            float t = Utils.GetLerpPercent(followPercent, followTime, Time.deltaTime);
            heldItem.MovePosition(Vector3.Lerp(heldItem.position, itemHolder.transform.position, t));
        }
    }
}
