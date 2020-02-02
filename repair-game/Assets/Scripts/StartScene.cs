using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{ 
    public Button btnContinue;
    public Button btnBack;
    public Button btnQuit;
    public Button btnPlay;

    public Canvas NextCanvas;
    public Canvas CurrentCanvas;
    public Canvas PreviousCanvas;

    // Start is called before the first frame update
    void Start()
    {
        if (btnContinue != null)
        {
            btnContinue.onClick.AddListener(Continue);
        }
        else
        {
            btnPlay.onClick.AddListener(Play);
        }
        if (btnBack != null)
        {
            btnBack.onClick.AddListener(Back);
        }
        else
        {
            btnQuit.onClick.AddListener(Quit);
        }
    }

    void Continue()
    {
        NextCanvas.enabled = true;
        CurrentCanvas.enabled = false;
    }

    void Back()
    {
        PreviousCanvas.enabled = true;
        CurrentCanvas.enabled = false;
    }

    void Play()
    {
        SceneManager.LoadScene("MainScene");
    }

    void Quit()
    {
        Application.Quit();
    }

    // Update is called once per frame

}
