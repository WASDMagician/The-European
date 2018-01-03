using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller : MonoBehaviour {

    public static Game_Controller game_controller;
    public enum game_states { playing, paused, examining};
    public game_states current_state;

    public static int flags_collected, flags_total;

    // Use this for initialization
    void Start () {
        game_controller = this;
	}
	
    public virtual void Switch_State(game_states _states)
    {
        current_state = _states;
    }

    public virtual game_states Get_State()
    {
        return current_state;
    }

    public virtual void Collectible_Increase()
    {

    }
}
