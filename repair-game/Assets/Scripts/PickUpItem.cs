using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public string itemTag;

    private Rigidbody rb;
    private Player player;

    void Start() {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (itemTag == collision.transform.tag)
        {
            player.DropItem();

            rb.isKinematic = true;
            transform.parent = collision.transform.root;
            tag = itemTag;
        }
    }
}
