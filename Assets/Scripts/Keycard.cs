using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycard : MonoBehaviour
{
    public string keycardName = "Keycard";
    
    private void OnMouseDown()
    {
        if (!GameManager.Instance.HasItem(keycardName))
        {
            GameManager.Instance.AddItem(keycardName);
            Debug.Log("Keycard picked up");
            Destroy(gameObject);
        }
    }
}
