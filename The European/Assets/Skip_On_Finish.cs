using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Skip_On_Finish : MonoBehaviour {

    VideoPlayer player;

	// Use this for initialization
	void Start () {
        player = GetComponent<VideoPlayer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(player.isPlaying == false || Input.anyKey)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("UK");
        }
	}
}
