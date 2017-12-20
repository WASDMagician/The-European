using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour {

    Rigidbody character_rigidbody;

    //avg walk speed 1.4m/s //max run speed 12.5m/s //jump force 5382 newtons (something is wrong here)
    [Range(1f, 12.5f)]
    public float move_speed;
    [Range(0f, 600f)]
    public float jump_force;

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 right = new Vector3(1, 0, 0);

    float cast_height;
    
	// Use this for initialization
	void Start () {
        cast_height = GetComponent<Collider>().bounds.extents.y;
        character_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float y_vel = character_rigidbody.velocity.y;
		if(Is_Grounded() == true && Input.GetKeyDown(KeyCode.Space))
        {
            character_rigidbody.AddForce(this.transform.up * jump_force, ForceMode.Impulse);
            y_vel = character_rigidbody.velocity.y;
        }
        character_rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * move_speed, y_vel, Input.GetAxis("Vertical") * move_speed);
        Debug.DrawRay(this.transform.position, -this.transform.up);
	}

    bool Is_Grounded()
    {
        Ray ray = new Ray(this.transform.position, -this.transform.up);
        RaycastHit hit_out;
        Physics.Raycast(ray, out hit_out, cast_height + 0.1f);
        if(hit_out.collider != null)
        {
            return true;
        }
        return false;
    }
}
