using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_State : MonoBehaviour {

    protected Rigidbody character_rigidbody;
    protected Character_Controller character_controller;

    private void Start()
    {
        Get_Character_Controller();
        Initialise();
    }

    public void Get_Character_Controller()
    {
        character_controller = GetComponent<Character_Controller>();
    }

    public virtual void Initialise()
    {

    }

	public virtual void Update_State()
    {

    }

    public virtual void Late_Update_State()
    {

    }

    public virtual void Switch_To()
    {

    }

    public virtual void Switch_From()
    {

    }
}
