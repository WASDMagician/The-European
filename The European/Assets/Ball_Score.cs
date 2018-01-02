using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Score : MonoBehaviour {

    public GameObject display_object;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ball"))
        {
            StartCoroutine(Goal_Celebration());
        }
    }

    IEnumerator Goal_Celebration()
    {
        display_object.SetActive(true);
        float end_time = Time.fixedTime + 2;
        while(Time.fixedTime < end_time)
        {
            display_object.transform.Rotate(display_object.transform.forward, 5);
            yield return new WaitForSeconds(0);
        }
        display_object.SetActive(false);
    }

}
