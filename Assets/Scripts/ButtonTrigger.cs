using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public Animator targetAnimator;
    public string animationTrigger;

    private void OnMouseDown()
    {
        if (targetAnimator != null)
        {
            targetAnimator.SetTrigger(animationTrigger);
        }
        //onButtonPressed?.Invoke();
    }
}
