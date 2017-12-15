using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Zipline : MonoBehaviour {

    public Transform target;
    public PathType path_type = PathType.Linear;
    public Transform[] waypoints;
    List<Vector3> waypoint_transforms = new List<Vector3>();
    public float speed;

	// Use this for initialization
	void Start () {
        for(int i = 0; i < waypoints.Length; i++)
        {
            waypoint_transforms.Add( waypoints[i].position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        target = other.gameObject.transform;
        Tween tw = target.DOPath(waypoint_transforms.ToArray(), speed, path_type).SetOptions(false);
        tw.OnComplete(Finish_Function);
        tw.SetEase(Ease.InOutSine).SetLoops(1);
    }

    void Finish_Function()
    {
        target = null;
    }
}
