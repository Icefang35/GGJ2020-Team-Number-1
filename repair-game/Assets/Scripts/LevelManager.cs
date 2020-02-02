using UnityEngine;
using Toolbox;

public class LevelManager : Manager<LevelManager>
{
    public bool hasLost = false;

    private ParentItem[] parentItems;

    void Start()
    {
        parentItems = Resources.FindObjectsOfTypeAll(typeof(ParentItem)) as ParentItem[];
    }

    void Update()
    {
        CheckForLoss();

        if (hasLost)
        {
            // Debug.Log("GAMEOVER");
        }
    }

    void CheckForLoss()
    {
        if (!hasLost)
        {
            foreach (ParentItem pi in parentItems)
            {
                if (pi.IsComplete())
                {
                    return;
                }
            }

            hasLost = true;
        }
    }
}
