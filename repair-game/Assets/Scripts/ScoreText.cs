using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    void Start()
    {
        Text t = GetComponent<Text>();
        t.text = "Score :" + Mathf.Round(LevelManager.totalTime);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
