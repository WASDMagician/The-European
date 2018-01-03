using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_State : MonoBehaviour {

    public static Game_State game_state;
    public enum game_states { playing, paused, examining};
    public game_states current_state;

	// Use this for initialization
	void Start () {
        game_state = this;
	}
	
    public void Switch_State(game_states _states)
    {
        current_state = _states;
    }

    public game_states Get_State()
    {
        return current_state;
    }
}
