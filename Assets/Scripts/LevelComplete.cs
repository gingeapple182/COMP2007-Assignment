using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    public GameObject levelScreenUI;

    void Start()
    {
        levelScreenUI.SetActive(false);
    }

    public void ShowLevelEndScreen()
    {
        levelScreenUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.SetGameState(GameState.Complete);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.SetGameState(GameState.Menu);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
