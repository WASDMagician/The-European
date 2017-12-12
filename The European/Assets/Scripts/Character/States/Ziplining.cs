using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziplining : Character_State {

    LayerMask[] zip_halt_layers;

    public override void State_Update()
    {
        base.State_Update();
    }

    private void Move()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        for(int i = 0; i < zip_halt_layers.Length; i++)
        {
            if(collision.gameObject.layer == zip_halt_layers[i])
            {
                //switch state
            }
        }
    }


}
