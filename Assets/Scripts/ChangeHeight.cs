using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class ChangeHeight : MonoBehaviour {

	void Update () {
		Transform arPlane = transform.Find("debugPlanePrefab(Clone)/Plane"); //Get the AR Plane child object
		if(arPlane != null){
			Vector3 rayPosition = new Vector3(arPlane.position.x, 1000, arPlane.position.z); //Create a new Rayfire at the same X & Z as the plane, but with Y + 1000
			RaycastHit hit; //Create hit data variable
			int layerMask = (1 << LayerMask.NameToLayer("Map")); //Only intersect with objects in the Map layer
			Debug.DrawLine(rayPosition, Vector3.down, Color.red, Mathf.Infinity); //Debug line to graphically display rays
			if (Physics.Raycast(rayPosition, Vector3.down, out hit, Mathf.Infinity, layerMask)) //Fire ray from position above, downwards an infinite length.
			{
				Vector3 arRootPos = this.transform.position; //Copy the current AR Root position to temp variable.
				Vector3 arPlaneOffset = arPlane.transform.position - this.transform.position; //Calculate offset between ARRoot location and actual plane location
				this.transform.position = new Vector3(arRootPos.x, hit.point.y - arPlaneOffset.y, arRootPos.z); //Change copied AR Root position accordingly, factoring in the height of the plane in relation to the AR Root object.
				//Debug.Log(new Vector3(arRootPos.x, hit.point.y - arPlane.position.y, arRootPos.z)); //Change copied AR Root position accordingly, factoring in the height of the plane in relation to the AR Root object.)
			}
		}
	}
}