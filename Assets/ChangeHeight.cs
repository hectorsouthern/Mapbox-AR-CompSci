using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Map;

public class ChangeHeight : MonoBehaviour {
	public Transform _thingToMove;
	public float _heightAboveGround = 1;

	private void Start()
	{
		//Default to moving the object itself.
		if( _thingToMove == null )
		{
			_thingToMove = transform;
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
				_thingToMove.transform.localPosition = new Vector3(_thingToMove.transform.localPosition.x, _thingToMove.transform.localPosition.y - distanceAboveGround + _heightAboveGround, _thingToMove.transform.localPosition.z);
			}
		}
	}

	public void setHeightAboveGround( float height)
	{
		_heightAboveGround = height;
	}
}