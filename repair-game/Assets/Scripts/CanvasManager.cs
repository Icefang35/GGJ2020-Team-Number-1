using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CanvasManager : MonoBehaviour {
    public Button continueButton;
    public Button quitButton;
    public Canvas pauseBox;
    public GameObject player;
    public GameObject playerCamera;
    public void Start()
    {
        pauseBox.GetComponent<Canvas>().enabled = false;
        quitButton.onClick.AddListener(quitGame);
        continueButton.onClick.AddListener(closeMenu);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKey(KeyCode.Escape))
        {
            openMenu();
        }
    }

    void openMenu() {
        pauseBox.GetComponent<Canvas>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<Player>().enabled = false;
        playerCamera.GetComponent <Toolbox.FirstPersonCamera>().enabled = false;
    }

    void closeMenu() {
        pauseBox.GetComponent<Canvas>().enabled = false;
        playerCamera.GetComponent<Toolbox.FirstPersonCamera>().enabled = true;
        player.GetComponent<Player>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void quitGame() {
        Application.Quit();
    }
}
