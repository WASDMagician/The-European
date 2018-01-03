using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Collectible_Info : Interactible {

    public Sprite display_sprite;

    public override void Interact(Character_State _interactor)
    {
        base.Interact(_interactor);
        if(Display_Image.display_image != null)
        {
            Display_Image.display_image.Display(display_sprite);
        }
    }

    public override void Stop_Interacting()
    {
        base.Stop_Interacting();
        if(Display_Image.display_image != null)
        {
            Display_Image.display_image.Hide();
        }
    }

}
