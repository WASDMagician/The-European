using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_Trigger : Phys_Obj {

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Activate()
    {
        base.Activate();
        if(animator == null)
        {
            print("NULL");
            animator = GetComponent<Animator>();
        }
        if(animator != null)
        {
            Disable_Collision_Trigger();
            animator.SetTrigger("Activate");
        }
    }

    void Disable_Collision_Trigger()
    {
        Collider collider = GetComponent<Collider>();
        if(collider != null)
        {
            collider.enabled = false;
        }
    }
}
