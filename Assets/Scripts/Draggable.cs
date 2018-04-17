﻿using UnityEngine;

using System.Collections;

[RequireComponent(typeof(BoxCollider))]

public class Draggable : MonoBehaviour {
	private Vector3 screenPoint;
	private Vector3 offset;
		
	void OnMouseDown(){
		screenPoint = GameObject.Find("MapCamera").GetComponent<Camera>().WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
		
	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = GameObject.Find("MapCamera").GetComponent<Camera>().ScreenToWorldPoint(cursorPoint);
		Debug.Log(cursorPosition);
		transform.position = cursorPosition;
	}
} 