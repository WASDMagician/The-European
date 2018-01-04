using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public float spin_speed;
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(Vector3.up * spin_speed * Time.deltaTime);
	}
}
