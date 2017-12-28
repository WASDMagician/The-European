using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climbing_State : Character_State {

    Climbable climbable;
    [Range(0.5f, 5f)]
    public float climb_speed, cast_distance;
    Vector3 gravity, head_vector, foot_vector;

    public override void Initialise()
    {
        base.Initialise();
        Get_Heights();
    }

    void Get_Heights()
    {
        Collider collider = GetComponent<Collider>();
        if(collider != null)
        {
            //vectors used to offset for casting
            head_vector = new Vector3(0, collider.bounds.extents.y, 0);
            foot_vector = new Vector3(0, -collider.bounds.extents.y, 0);
        }
    }

    public override void Switch_To()
    {
        base.Switch_To();
        //turn gravity off
        gravity = Physics.gravity;
        Physics.gravity = Vector3.zero;
    }

    public override void Switch_From()
    {
        base.Switch_From();
        //turn gravity on
        Physics.gravity = gravity;
    }

    public override void Late_Update_State()
    {
        base.Late_Update_State();
    }

    public override void Update_State()
    {
        base.Update_State();
        Climb();
        Climb_Check();
    }

    public void Climb()
    {
        if (climbable != null)
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            if (hor != 0 || ver != 0)
            {
                Vector3 key_input = new Vector3(hor, 0, ver); //input vector
                float angle = Vector3.SignedAngle(key_input, climbable.transform.forward, this.transform.up); //angle between the players input and the climbable object;
                Vector3 vec = new Vector3(Mathf.Sin(Mathf.Deg2Rad * angle), -Mathf.Cos(Mathf.Deg2Rad * angle), 0); //convert angle to movement vector
                vec = this.transform.TransformDirection(vec); //convert vector to local space
                if (character_rigidbody == null)
                {
                    character_rigidbody = GetComponent<Rigidbody>();
                }
                if (character_rigidbody != null)
                {
                    character_rigidbody.velocity = vec * climb_speed;
                }
            }
            else
            {
                character_rigidbody.velocity = Vector3.zero;
            }
        }
    }

    void Climb_Check()
    {
        if(Climbable_Hit() == false)
        {
            character_controller.Switch_State(character_controller.standing);
        }
    }

    //cast from each body point to check for climbable surface
    bool Climbable_Hit()
    {
        Climbable climbable = null;
        //head cast
        climbable = Cast_For_Climbable(this.transform.position + head_vector, this.transform.forward);
        if(climbable != null)
        {
            return true;
        }
        //body cast
        climbable = Cast_For_Climbable(this.transform.position, this.transform.forward);
        if(climbable != null)
        {
            return true;
        }
        //foot cast
        climbable = Cast_For_Climbable(this.transform.position + foot_vector, this.transform.forward);
        return climbable != null;
    }

    Climbable Cast_For_Climbable(Vector3 _position, Vector3 _direction)
    {
        Climbable climbable = null;
        RaycastHit hit_out;
        Ray ray = new Ray(_position, _direction);
        Physics.Raycast(ray, out hit_out, cast_distance);
        if(hit_out.collider != null)
        {
            climbable = hit_out.collider.GetComponent<Climbable>();
        }
        return climbable;
    }

    bool On_Ground()
    {
        return Physics.Raycast(new Ray(this.transform.position + foot_vector, -this.transform.up), cast_distance);
    }
    

    private void OnCollisionEnter(Collision collision)
    {
        Climbable temp_climbable = collision.gameObject.GetComponent<Climbable>();
        if(temp_climbable != null)
        {
            climbable = temp_climbable;
        }
        else
        {
            character_controller.Switch_State(character_controller.standing);
        }
    }
}
