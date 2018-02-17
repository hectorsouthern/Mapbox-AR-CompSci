using System;
using System.Collections;
using System.Collections.Generic;
using UnityARInterface;
using UnityEngine;

public class ChangeHeight : MonoBehaviour {

	public static Action<BoundedPlane> planeAdded;

	// Use this for initialization
	void Start () {
		planeAdded += getPlaneAdded;
	}
	
	// Update is called once per frame
	void getPlaneAdded (BoundedPlane plane) {
		Debug.Log(plane.height);
	}
}
