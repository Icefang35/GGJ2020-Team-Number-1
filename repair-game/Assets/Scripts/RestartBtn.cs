using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartBtn : MonoBehaviour
{
    public void quitGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}
