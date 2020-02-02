using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {
    public Button continueButton;
    public Button quitButton;
    public Canvas pauseBox;
    public GameObject player;
    public GameObject playerCamera;

    public static bool isPaused = false;

    public Scene StartScene { get; private set; }

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
        isPaused = true;
        pauseBox.GetComponent<Canvas>().enabled = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        player.GetComponent<Player>().enabled = false;
        playerCamera.GetComponent <Toolbox.FirstPersonCamera>().enabled = false;
    }

    void closeMenu() {
        isPaused = false;
        pauseBox.GetComponent<Canvas>().enabled = false;
        playerCamera.GetComponent<Toolbox.FirstPersonCamera>().enabled = true;
        player.GetComponent<Player>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void quitGame() {
        SceneManager.LoadScene("StartScene");
    }
}
