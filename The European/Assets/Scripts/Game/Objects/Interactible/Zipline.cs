using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Zipline : MonoBehaviour {

    public Transform target;
    public PathType path_type = PathType.Linear;
    public Vector3[] waypoints;
    public float speed;

	// Use this for initialization
	void Start () {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        target = other.gameObject.transform;
        Tween tw = target.DOPath(waypoints, speed, path_type).SetOptions(false);
        tw.OnComplete(Finish_Function);
        tw.SetEase(Ease.InOutSine).SetLoops(1);
    }

    void Finish_Function()
    {
        target = null;
    }
}
