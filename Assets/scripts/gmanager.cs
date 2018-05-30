using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gmanager : MonoBehaviour {

	private float size;
	public GameObject platForm;
	public GameObject gems;

	private Vector3 lastPosition;
	void Start () {
		size = platForm.transform.localScale.x;
		lastPosition = platForm.transform.position;
		for (int i = 0; i < 5; i++)
			SpawnsZ();

		InvokeRepeating ("SpawnsPlatform", 2f, 0.25f);
	}


	private void SpawnsPlatform(){
		if(player.scoreUpdate==true)
		{
			
		   int random = Random.Range (0, 6);
		   int gemsRand = Random.Range (0, 7);
		   if (random < 3)
			SpawnsX ();
		   if (random >= 3)
			SpawnsZ ();

		    if (gemsRand < 2) {
			SpawnsGems ();
		}
	   }
	}
	private void SpawnsGems(){
		Instantiate (gems, lastPosition + new Vector3(0f,0.7f,0f), gems.transform.rotation);
	}

	private void SpawnsX()
	{
		GameObject _platForm = Instantiate (platForm)as GameObject;
		_platForm.transform.position = lastPosition + new Vector3 (size, 0f, 0f);
		lastPosition = _platForm.transform.position;
	}
	private void SpawnsZ()
	{
		GameObject _platForm = Instantiate (platForm)as GameObject;
		_platForm.transform.position = lastPosition + new Vector3 (0f, 0f,size);
		lastPosition = _platForm.transform.position;

	}

	public void StopSpwans(){
		CancelInvoke ("SpawnsPlatform");
	}
}
