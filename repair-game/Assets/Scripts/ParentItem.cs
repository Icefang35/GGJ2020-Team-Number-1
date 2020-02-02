using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentItem : MonoBehaviour
{
    public float retagTime = 0.5f;

    private string itemTag;
    private List<PickUpItem> itemPieces;

    private int stuckCount;

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

        stuckCount = itemPieces.Count;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Explode();
        }
    }

    public void Explode()
    {
        tag = "Untagged";
        StartCoroutine(Retag());

        foreach (PickUpItem child in itemPieces)
        {
            child.Explode();
        }
    }

    IEnumerator Retag()
    {
        yield return new WaitForSeconds(retagTime);
        tag = itemTag;
    }

    public bool IsComplete()
    {
        int count = 0;

        foreach (Transform child in transform)
        {
            if (child.tag == tag)
            {
                count++;
            }
        }

        return count == stuckCount;
    }
}
