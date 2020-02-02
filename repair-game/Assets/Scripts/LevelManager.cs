using UnityEngine;
using Toolbox;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

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
            StartCoroutine(GameOver());
        }
        else if (!CanvasManager.isPaused)
        {
            totalTime += Time.deltaTime;
        }
    }

    IEnumerator GameOver()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOverScene");
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
