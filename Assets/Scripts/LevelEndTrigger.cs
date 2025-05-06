using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public LevelComplete levelEndScreen;
        
    void OnMouseDown()
    {
        if (levelEndScreen != null)
        {
            levelEndScreen.ShowLevelEndScreen();
        }
        else
        {
            Debug.LogWarning("level end screen not assigned");
        }
    }
}
