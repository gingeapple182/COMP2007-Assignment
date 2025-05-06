using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject pauseMenuUI;
    public GameObject deathScreenUI;
    public GameObject endScreenUI;

    IEnumerator Start()
    {
        yield return null;

        Debug.Log("Showing main menu on launch");
        Time.timeScale = 0f; //pause the game
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        GameManager.Instance.SetGameState(GameState.Menu);
        mainMenuUI.SetActive(true);
        pauseMenuUI.SetActive(false);
        deathScreenUI.SetActive(false);
        endScreenUI.SetActive(false);
    }

    public void PlayGame()
    {
        Debug.Log("PLAY BUTTON CLICKED");
        Time.timeScale = 1f; //start the game
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GameManager.Instance.SetGameState(GameState.Playing);
        mainMenuUI.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
