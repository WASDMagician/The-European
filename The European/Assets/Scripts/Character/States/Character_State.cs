﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_State : MonoBehaviour {

    protected Rigidbody character_rigidbody;
    protected Character_Controller character_controller;
    protected Animator character_animator;

    private void Start()
    {
        Get_Character_Controller();
        Initialise();
    }

    public void Get_Character_Controller()
    {
        character_controller = GetComponent<Character_Controller>();
        if(character_controller == null)
        {
            Debug.Log("Character Controller not found.");
        }
    }
    
    public void Get_Character_Animator()
    {
        character_animator = GetComponent<Animator>();
        if(character_animator == null)
        {
            Debug.Log("Animator not found.");
        }
    }

    public virtual void Initialise()
    {

    }

	public virtual void Update_State()
    {
        Update_Animator();
    }

    public virtual void Late_Update_State()
    {

    }

    public virtual void Update_Animator()
    {
        if(character_animator == null)
        {
            character_animator = GetComponent<Animator>();
        }
        if(character_animator != null)
        {
            character_animator.SetFloat("Speed", character_rigidbody.velocity.magnitude);
        }
    }

    public virtual void Switch_To()
    {

    }

    public virtual void Switch_From()
    {

    }
}
