using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHeight : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Vector3 origin = this.gameObject.transform.position;
		origin = new Vector3(origin.x, origin.y + 1000, origin.z);
		RaycastHit hit;
		if (Physics.Raycast(origin, Vector3.down, out hit, Mathf.Infinity, 1 << 9)){
			Debug.Log(hit.transform.position);
			Debug.Log(hit.collider.gameObject.name);
			this.gameObject.transform.position = hit.transform.position;
		}
	}
}
