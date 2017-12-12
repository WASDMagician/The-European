﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phys_Obj_Trigger : MonoBehaviour {
    public string[] ids;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Phys_Obj obj = other.gameObject.GetComponent<Phys_Obj>();
        for(int i = 0; i < ids.Length; i++)
        {
            if(obj.id == ids[i])
            {
                print("ACTIVATE");
                obj.Activate();
            }
        }
    }
}