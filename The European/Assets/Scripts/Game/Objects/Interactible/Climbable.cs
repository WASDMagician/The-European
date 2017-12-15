using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbable : Interactible {

    public override void Interact()
    {
        base.Interact();
    }

    public override void Interact(Character_Controller _character_controller)
    {
        base.Interact(_character_controller);
        
    }
}
