using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Animator targetAnimator;
    public string animationTrigger;

    [Header("Optional Requirement?")]
    public bool requiresKeycard = false;
    public string requiredItem = "Keycard";

    private void OnMouseDown()
    {
        if (requiresKeycard)
        {
            if (GameManager.Instance != null && GameManager.Instance.HasItem(requiredItem))
            {
                TriggerAnimation();
            }
            else
            {
                Debug.Log("Access Denied: Requires Keycard.");
            }
        }
        else
        {
            TriggerAnimation();
        }
    }

    private void TriggerAnimation()
    {
        if (targetAnimator != null && !string.IsNullOrEmpty(animationTrigger))
        {
            targetAnimator.SetTrigger(animationTrigger);
        }
        else
        {
            Debug.LogWarning("No animator or trigger set");
        }
    }



}
