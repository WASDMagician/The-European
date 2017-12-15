using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Standing))]
public class Character_Controller : MonoBehaviour {
    public Standing standing;
    public Character_State current_state;

	// Use this for initialization
	void Start () {
        current_state = standing;
	}

    private void Update()
    {
        if (current_state != null)
        {
            current_state.State_Update();
        }
    }

    private void LateUpdate()
    {
        if (current_state != null)
        {
            current_state.State_Late_Update();
        }
    }

    public void Switch_State(Character_State _state)
    {
        if(_state != current_state)
        {
            current_state.On_Switch_From();
            current_state = _state;
            current_state.On_Switch_To();
        }
    }
}
