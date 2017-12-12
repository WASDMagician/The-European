using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing : Character_State {

    public float speed;
    Interactible interactible;

    public override void State_Late_Update()
    {
        base.State_Late_Update();
        Move();
    }

    public override void State_Update()
    {
        base.State_Update();
        Button_Press();
    }

    void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        character_rigidbody.velocity = move * speed;
    }

    void Button_Press()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(interactible != null)
            {
                interactible.Interact();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Interactible>() != null)
        {
            interactible = collision.gameObject.GetComponent<Interactible>();
        }
    }
}
