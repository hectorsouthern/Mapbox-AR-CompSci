using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obscured : MonoBehaviour {

	// Use this for initialization
	void Start () {
		this.GetComponent<Renderer>().material.renderQueue = 2002;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
