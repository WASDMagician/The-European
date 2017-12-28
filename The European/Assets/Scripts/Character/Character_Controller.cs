using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {

    public Character_State standing, climbing;
    Character_State current_state;

    private void Start()
    {
        if (standing != null)
        {
            current_state = standing;
        }
        else
        {
            Debug.Log("Standing state not found.");
        }
    }

    private void Update()
    {
        current_state.Update_State();
    }
    
    private void LateUpdate()
    {
        current_state.Late_Update_State();
    }

    public void Switch_State(Character_State _state)
    {
        if(_state != current_state)
        {
            current_state.Switch_From();
            current_state = _state;
            current_state.Switch_To();
        }
    }

}
