using Toolbox;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform itemHolder;

    [Tooltip("Percent of the way to the target it should follow."), Range(0.001f, 1f)]
    public float followPercent = 0.1f;
    [Tooltip("Time it takes to interpolate follow percent of the way to the target."), Range(0.001f, 1f)]
    public float followTime = 1f / 60f;

    public float pickUpDist = 3f;

    public float throwAmount = 10f;

    public Rigidbody heldItem;

    private Transform playerCamera;

    public LayerMask heldDistMask = Physics.DefaultRaycastLayers;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main.transform;
        }
    }

    Vector3 lastPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, pickUpDist))
            {
                if (hit.transform.tag == "Holdable")
                {
                    heldItem = hit.transform.GetComponent<Rigidbody>();
                    heldItem.useGravity = false;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            DropItem();
        }
    }

    public void DropItem()
    {
        if (heldItem)
        {
            heldItem.useGravity = true;
            heldItem.GetComponent<Rigidbody>().AddForce(playerCamera.forward * throwAmount, ForceMode.Impulse);
            heldItem = null;
        }
    }

    void LateUpdate()
    {
        if (heldItem)
        {
            Vector3 delta = itemHolder.position - playerCamera.position;
            float holdDist = delta.magnitude;

            if (Physics.Raycast(playerCamera.position, delta.normalized, out RaycastHit hitInfo, holdDist, heldDistMask))
            {
                holdDist = hitInfo.distance - 0.1f;
            }

            float t = Utils.GetLerpPercent(followPercent, followTime, Time.deltaTime);
            Vector3 pos = playerCamera.position + (delta.normalized * holdDist);
            heldItem.transform.position = Vector3.Lerp(heldItem.transform.position, pos, t);
        }
    }
}
