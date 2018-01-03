using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Display_Collectible_Info : Interactible {

    public Sprite display_sprite;
    public enum country_contained_in { uk, france, ireland, austria};
    public country_contained_in country;
    bool collected = false;

    public override void Interact(Character_State _interactor)
    {
        base.Interact(_interactor);
        if (collected == false)
        {
            collected = true;
            if(country == country_contained_in.uk)
            {
                Game_Controller.game_controller.Collectible_Increase();
            }
        }
        if(Display_Image.display_image != null && Game_Controller.game_controller != null)
        { 
            Game_Controller.game_controller.Switch_State(Game_Controller.game_states.examining);
            Display_Image.display_image.Display(display_sprite);  
        }
    }

    public override void Stop_Interacting()
    {
        base.Stop_Interacting();
        if(Display_Image.display_image != null && Game_Controller.game_controller != null)
        {
            Game_Controller.game_controller.Switch_State(Game_Controller.game_states.playing);
            Display_Image.display_image.Hide();
        }
    }

}
