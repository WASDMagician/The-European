using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Controller_UK : Game_Controller {

    public static int collected_uk, total_uk;
    Collectible_Complete_UK collectible_complete;

    // Use this for initialization
    void Start () {
        game_controller = this;
        collectible_complete = FindObjectOfType<Collectible_Complete_UK>();
        total_uk = 4;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Collectible_Increase()
    {
        base.Collectible_Increase();
        collected_uk++;
        if(collected_uk == total_uk)
        {
            collectible_complete.Trigger_Completion();
        }
    }
}
