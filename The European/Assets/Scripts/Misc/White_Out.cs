using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class White_Out : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Material[] materials = GetComponent<MeshRenderer>().sharedMaterials;
        for(int i = 0; i < materials.Length; i++)
        {
            materials[i].color = Color.white;
        }
        DestroyImmediate(this);
	}
}
