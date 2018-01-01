using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour {
    public GameObject player_object;
    public Vector3 offset;
    public Vector3 rotation;
    public float follow_speed;
    public Vector3 min_position, max_position;

	// Use this for initialization
	void Start () {
        player_object = FindObjectOfType<Character_Controller>().gameObject;
        if(player_object == null)
        {
            Debug.Log("Player_Controller not found: " + this.name + " | " + this.GetType());
        }
	}
	
	// Update is called once per frame
	void Update () {
        Update_Camera();
        Keep_In_Bounds();
	}

    void Update_Camera()
    {
        if(player_object != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, player_object.transform.position + offset, follow_speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(rotation);
        }
    }

    void Keep_In_Bounds()
    {
        Vector3 position = this.transform.position;
        if(position.x < min_position.x)
        {
            position.x = min_position.x;
        }
        if (position.x > max_position.x)
        {
            position.x = max_position.x;
        }
        if(position.y < min_position.y)
        {
            position.y = min_position.y;
        }
        if(position.y > max_position.y)
        {
            position.y = max_position.y;
        }
        if(position.z < min_position.z)
        {
            position.z = min_position.z;
        }
        if(position.z > max_position.z)
        {
            position.z = max_position.z;
        }
        this.transform.position = position;
    }
}
