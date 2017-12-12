using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_State : MonoBehaviour {

    protected Character_Controller character_controller;
    protected Rigidbody character_rigidbody;

    private void Awake()
    {
        character_controller = GetComponent<Character_Controller>();
        character_rigidbody = GetComponent<Rigidbody>();
    }

    public virtual void On_Switch_To()
    {

    }

    public virtual void On_Switch_From()
    {

    }

    public virtual void State_Update()
    {

    }

    public virtual void State_Late_Update()
    {

    }
}
