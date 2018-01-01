using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book_Collision : MonoBehaviour {

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Book"))
        {
            Collider collider = GetComponent<Collider>();
            collider.enabled = false;
            if(animator == null)
            {
                animator = GetComponent<Animator>();
            }
            if(animator != null)
            {
                animator.SetTrigger("Activate");
            }
        }
    }

}
