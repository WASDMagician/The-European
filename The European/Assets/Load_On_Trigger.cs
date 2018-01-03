using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Load_On_Trigger : MonoBehaviour {

    public string level_name;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(level_name);
        }
    }
}
