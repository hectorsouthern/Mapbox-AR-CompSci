using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockToZero : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = new Vector3(transform.position.x,0,transform.position.z);
		Debug.Log(this.gameObject.transform.position);
	}
}
