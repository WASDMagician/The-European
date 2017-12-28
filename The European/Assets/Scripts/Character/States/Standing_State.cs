﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Standing_State : Character_State {

    //avg walk speed 1.4m/s //max run speed 12.5m/s //jump force 5382 newtons (something is wrong here)
    [Range(1f, 12.5f)]
    public float move_speed;
    [Range(0f, 600f)]
    public float jump_force;

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 right = new Vector3(1, 0, 0);

    float cast_height;

    public override void Initialise()
    {
        base.Initialise();
        cast_height = GetComponent<Collider>().bounds.extents.y;
        character_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update_State()
    {
        float y_vel = character_rigidbody.velocity.y;
        if (Input.GetKeyDown(KeyCode.Space) && Is_Grounded() == true)
        {
            character_rigidbody.AddForce(this.transform.up * jump_force, ForceMode.Impulse);
            y_vel = character_rigidbody.velocity.y;
        }
        character_rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * move_speed, y_vel, Input.GetAxis("Vertical") * move_speed);
        if (Input.anyKey)
        {
            Set_Direction(character_rigidbody.velocity);
        }
    }

    void Set_Direction(Vector3 _input)
    {
        _input.y = 0;
        this.transform.forward = _input;
    }

    bool Is_Grounded()
    {
        Ray ray = new Ray(this.transform.position, -this.transform.up);
        RaycastHit hit_out;
        Physics.Raycast(ray, out hit_out, cast_height + 0.1f);
        if (hit_out.collider != null)
        {
            return true;
        }
        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Climbable climbable = collision.gameObject.GetComponent<Climbable>();
        if(climbable != null)
        {
            character_controller.Switch_State(character_controller.climbing);
        }
    }

}
