using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject deathScreenUI;

    void Start()
    {
        deathScreenUI.SetActive(false);
    }

    public void ShowDeathScreen()
    {
        deathScreenUI.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.SetGameState(GameState.Dead);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.SetGameState(GameState.Menu);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void MainMenu()
    {
        return;
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
