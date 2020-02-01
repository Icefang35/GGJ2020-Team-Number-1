using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentItem : MonoBehaviour
{
    public float retagTime = 0.5f;

    private string itemTag;
    private List<PickUpItem> itemPieces;

    void Start()
    {
        itemTag = tag;

        itemPieces = new List<PickUpItem>();

        foreach (Transform child in transform)
        {
            if (child.tag == tag)
            {
                itemPieces.Add(child.GetComponent<PickUpItem>());
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            tag = "Untagged";
            StartCoroutine(Retag());

            foreach (PickUpItem child in itemPieces)
            {
                child.Explode();
            }

        }
    }

    IEnumerator Retag()
    {
        yield return new WaitForSeconds(retagTime);
        tag = itemTag;
    }
}
