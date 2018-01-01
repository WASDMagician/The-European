using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactible : MonoBehaviour {

    public Character_State interactor;

	public virtual void Interact(Character_State _interactor)
    {
        interactor = _interactor;
        interactor.Set_Interactible(this);
    }

    public virtual void Stop_Interacting()
    {
        interactor = null;
    }
}
