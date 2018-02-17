using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class RaycastHeight : MonoBehaviour {
	public Transform _MainCamera;
	public float _heightAboveGround = 1;

	private void Start()
	{
		//Default to moving the object itself.
		if( _MainCamera == null )
		{
			_MainCamera = transform;
		}
	}

	void Update () {

		//TODO: Probably don't need to do this *every* frame.

		RaycastHit hit;
		//Simulate a ray from 1000m above the user to find out how far above/below the ground they are.
		int layerMask = (1 << LayerMask.NameToLayer("Map")); //Only intersect with the "map" layer.
		if (Physics.Raycast(this.transform.position + new Vector3(0, 1000, 0), Vector3.down, out hit, Mathf.Infinity, layerMask))
		{
			float distanceAboveGround = hit.distance - 1000;
			if (distanceAboveGround < _heightAboveGround*0.9 || distanceAboveGround > _heightAboveGround*1.1 || Math.Abs(distanceAboveGround - _heightAboveGround) > 1)
			{
				//Debug.Log(name+" is " + distanceAboveGround + "m above the ground. Moving "+ _thingToMove.name + "...");
				_MainCamera.transform.localPosition = new Vector3(_MainCamera.transform.localPosition.x, _MainCamera.transform.localPosition.y - distanceAboveGround + _heightAboveGround, _MainCamera.transform.localPosition.z);
			}
		}
	}

	public void setHeightAboveGround( float height)
	{
		_heightAboveGround = height;
	}
}