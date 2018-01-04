using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible_Complete_UK : Collectible_Complete_Trigger {

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Trigger_Completion()
    {
        base.Trigger_Completion();
        if(animator == null)
        {
            animator = GetComponent<Animator>();
        }
        if(animator != null)
        {
            animator.SetTrigger("Open");
        }
    }
}
