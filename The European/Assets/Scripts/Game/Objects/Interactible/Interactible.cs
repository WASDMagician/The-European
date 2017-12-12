using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour {

    protected Character_Controller character_controller;

	public virtual void Interact()
    {

    }

    public virtual void Interact(Character_Controller _character_controller)
    {
        character_controller = _character_controller;
    }
}
