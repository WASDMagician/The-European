using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow_Player : MonoBehaviour {
    public GameObject player_object;
    public Vector3 offset;
    public Vector3 rotation;
    public float follow_speed;

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
	}

    void Update_Camera()
    {
        if(player_object != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, player_object.transform.position + offset, follow_speed * Time.deltaTime);
            this.transform.rotation = Quaternion.Euler(rotation);
        }
    }
}
