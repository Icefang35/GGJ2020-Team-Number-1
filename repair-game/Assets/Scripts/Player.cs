using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform itemHolder;
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
                    heldItem.GetComponent<Rigidbody>().isKinematic = true;
                    // heldItem.GetComponent<Rigidbody>().useGravity = false;
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && heldItem)
        {
            heldItem.GetComponent<Rigidbody>().isKinematic = false;
            // heldItem.GetComponent<Rigidbody>().useGravity = true;
            heldItem.parent = null;
            heldItem = null;
        }
    }
}
