using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeightToMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, 1 << 9))
        {
			transform.position = hit.point;
		}
	}
}
