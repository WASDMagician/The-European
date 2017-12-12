using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Standing))]
public class Character_Controller : MonoBehaviour {
    public Character_State standing;
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
}
