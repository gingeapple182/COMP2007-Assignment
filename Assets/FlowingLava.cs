using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowingLava : MonoBehaviour
{
    public float scrollSpeed = 0.2f; // Adjust for faster/slower flow
    private Renderer lavaRenderer;
    private Vector2 textureOffset;

    void Start()
    {
        // Get the material's renderer component
        lavaRenderer = GetComponent<Renderer>();

        // Ensure initial offset starts at (0,0)
        textureOffset = Vector2.zero;
    }

    void Update()
    {
        // Scroll the texture over time
        textureOffset.x += scrollSpeed * Time.deltaTime;

        // Apply the new offset to the material
        lavaRenderer.material.mainTextureOffset = textureOffset;
    }
}
