using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Playing,
    Paused,
    Dead,
    Menu,
    Complete
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState CurrentGameState = GameState.Playing;
    private HashSet<string> inventory = new HashSet<string> ();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   public void SetGameState(GameState state)
    {
        CurrentGameState = state;
    }

    public void AddItem(string itemName)
    {
        inventory.Add(itemName);
        Debug.Log("Item added to inventory: " + itemName);
    }

    public bool HasItem(string itemName)
    {
        return inventory.Contains(itemName);
    }
}
