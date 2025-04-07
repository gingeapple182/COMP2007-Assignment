using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowingLava : MonoBehaviour
{
    [Header("Texture scrolling stuff")]
    public float scrollSpeed = 0.2f; // Adjust for faster/slower flow
    private Renderer lavaRenderer;
    private Vector2 textureOffset;

    [Header("Rising lava stuff")]
    public float risingSpeed = 0.0f;

    void Start()
    {
        lavaRenderer = GetComponent<Renderer>();
        textureOffset = Vector2.zero;
    }

    void Update()
    {
        // Scroll the texture
        textureOffset.x += scrollSpeed * Time.deltaTime;
        lavaRenderer.material.mainTextureOffset = textureOffset;

        transform.position += Vector3.up * risingSpeed * Time.deltaTime;
    }
}
