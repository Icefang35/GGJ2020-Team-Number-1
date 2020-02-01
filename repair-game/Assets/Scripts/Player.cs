using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform itemHolder;
    public float maxDistanceDelta = 0.1f;
    
    private Transform heldItem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
            {
                if (hit.transform.tag == "Holdable")
                {
                    heldItem = hit.transform;
                    heldItem.parent = itemHolder;
                    heldItem.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && heldItem)
        {
            heldItem.GetComponent<Rigidbody>().useGravity = true;
            heldItem.parent = null;
            heldItem = null;
        }

        if(heldItem) {
            heldItem.position = Vector3.MoveTowards(heldItem.position, itemHolder.transform.position, maxDistanceDelta);
        }
    }
}
