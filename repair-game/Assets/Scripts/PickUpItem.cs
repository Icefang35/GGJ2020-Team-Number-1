using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public string itemTag;
    public float explodeAmount = 15f;

    private Transform itemParent;
    private Rigidbody rb;
    private Player player;

    void Start()
    {
        itemParent = transform.parent;
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (itemTag == collision.transform.tag)
        {
            player.DropItem();

            Stick();
        }
    }

    private void Stick()
    {
        rb.isKinematic = true;
        transform.parent = itemParent.root;
        tag = itemTag;
    }

    public void Explode()
    {
        tag = "Holdable";
        rb.isKinematic = false;
        transform.parent = null;

        Vector3 dir = Random.onUnitSphere;

        if (dir.y < 0)
        {
            dir.y *= -1;
        }

        rb.AddForce(dir * explodeAmount, ForceMode.Impulse);
    }
}
