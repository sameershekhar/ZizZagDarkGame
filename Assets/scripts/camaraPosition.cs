using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camaraPosition : MonoBehaviour {

	public Transform target;
	public player play;
	Vector3 offset;
	void Start () {
		offset = target.transform.position - this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (play.canMove) {
			
			Vector3 reqPos = target.transform.position - offset;
			this.transform.position = Vector3.Lerp (this.transform.position, reqPos, 1.5f);
		}
	}
}
