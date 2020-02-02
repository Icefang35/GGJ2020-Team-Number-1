using UnityEngine;
using Toolbox;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : Manager<LevelManager>
{
    public CanvasManager canvasManager;
    public bool hasLost = false;

    public GameObject gameOverUI;
    public Text score;

    private ParentItem[] parentItems;

    public static float totalTime;

    void Start()
    {
        totalTime = 0f;
        hasLost = false;
        parentItems = Resources.FindObjectsOfTypeAll(typeof(ParentItem)) as ParentItem[];
    }

    void Update()
    {
        CheckForLoss();

        if (hasLost)
        {
            SceneManager.LoadScene("GameOverScene");
        }
        else if (!CanvasManager.isPaused)
        {
            totalTime += Time.deltaTime;
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
