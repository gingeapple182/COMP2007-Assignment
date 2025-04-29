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
    public float delayLower;
    public float delayHigher;

    private bool canRise = false;

    void Start()
    {
        lavaRenderer = GetComponent<Renderer>();
        textureOffset = Vector2.zero;
        StartCoroutine(StartLavaRising());
    }

    void Update()
    {
        // Scroll the texture
        textureOffset.x += scrollSpeed * Time.deltaTime;
        lavaRenderer.material.mainTextureOffset = textureOffset;

        if (canRise)
        {
            transform.position += Vector3.up * risingSpeed * Time.deltaTime;
        }
    }

    private IEnumerator StartLavaRising()
    {
        float delay = Random.Range(delayLower, delayHigher);
        yield return new WaitForSeconds(delay);

        canRise = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerMovement player = other.GetComponent<PlayerMovement>();
            if (player != null)
            {
                player.Die();
            }
        }
    }
}
