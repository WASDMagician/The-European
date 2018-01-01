using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class White_Out_Instance : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Material[] materials = GetComponent<SkinnedMeshRenderer>().materials;
        for (int i = 0; i < materials.Length; i++)
        {
            materials[i].color = Color.white;
        }
        DestroyImmediate(this);
    }
	
}
