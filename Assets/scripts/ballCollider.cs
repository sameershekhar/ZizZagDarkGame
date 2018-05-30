using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballCollider : MonoBehaviour {

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject, 1f);

			//Invoke ("FallDown", 1f);
		}
		
	}



}
