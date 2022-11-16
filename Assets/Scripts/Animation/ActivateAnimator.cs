using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimator : MonoBehaviour
{
    public Animator animatorToActivate;
    // Start is called before the first frame update
    void Start()
    {
        animatorToActivate.enabled = true;
    }
}
