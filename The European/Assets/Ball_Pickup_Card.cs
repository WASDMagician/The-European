﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Pickup_Card : MonoBehaviour {

    public Image image;
    int pickup_count = 0;

    public void Picked_Up()
    {
        pickup_count++;
        if (pickup_count >= 2)
        {
            StartCoroutine(Send_Off());
            
        }
    }

    IEnumerator Send_Off()
    {
        Game_Controller_UK.game_controller.Switch_State(Game_Controller.game_states.examining);
        image.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        image.gameObject.SetActive(false);
        Destroy(this.gameObject);
        Game_Controller_UK.game_controller.Switch_State(Game_Controller.game_states.playing);
    }
}
