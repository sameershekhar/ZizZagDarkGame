using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour {



	private Rigidbody rb;

	public Button[] buttons;
	public Button pauseButton;
	public Text gameOver;
	public Text BestScoreText;
	public Text ScoreText;
	private int Score;
	private int bestScore=0;
	private int bestScore1=0;

	public AdManager admgr;

	public Text tapTopPlay;
	private bool isMovingRight=false;
	[HideInInspector]


	public bool canMove = true;
	[HideInInspector]
	public static bool scoreUpdate=false;

	public audoimanager am;


	[SerializeField]
	GameObject particle;
	public gmanager manager;
	public float speed = 4f;

	// Use this for initialization
	void Start () {
		Score = 0;

		bestScore = PlayerPrefs.GetInt ("Best", 0);
		bestScore1 = PlayerPrefs.GetInt ("Best1", 0);
		rb=this.GetComponent<Rigidbody>();

		InvokeRepeating ("UpdateScore", 0f, 0.2f);

	}




	// Update is called once per frame
	void Update () {


		//BestScoreText.text ="Best: " + PlayerPrefs.GetInt ("Best");

		if (Input.GetMouseButtonDown(0) && canMove) {
			tapTopPlay.gameObject.SetActive (false);
			scoreUpdate=true;
			changeBoolean ();
			changeDirection ();
		}

		if (Physics.Raycast (this.transform.position, Vector3.down * 2) == false) {
			rb.velocity =new Vector3(0f, -speed, 0f);
			canMove = false;
			scoreUpdate = false;
			CancelInvoke ("UpdateScore");
			manager.StopSpwans ();

			Invoke ("GameOver", 1.5f);
		}
	}





	private void changeBoolean(){
		isMovingRight = !isMovingRight;
	}



	private void changeDirection(){
		if (isMovingRight) {
			rb.velocity = new Vector3 (speed, 0f, 0f);
		} else {
			rb.velocity = new Vector3 (0f, 0f, speed);
		}
	}



	public void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Gem") {
			am.pingSound.Play ();
			Destroy (col.gameObject);
			Score += 5;
			GameObject _particle = Instantiate (particle) as GameObject;
			_particle.transform.position = this.transform.position;
			Destroy (_particle, 1f);
		}
			
	}

	private void UpdateScore(){
		if (scoreUpdate == true) {
			Score += 1;
			ScoreText.text = Score.ToString ();
		}
	}



	private void GameOver(){

		//int x = PlayerPrefs.GetInt ("BestScore");
		AdManager.ShowAd();
		tapTopPlay.gameObject.SetActive (false);
		BestScoreText.gameObject.SetActive (true);
		if (SceneManager.GetActiveScene ().buildIndex == 1) {
			if (bestScore < Score) {
				PlayerPrefs.SetInt ("Best", Score);
				bestScore = Score;
				BestScoreText.text = "Best: " + bestScore.ToString ();

			} else {
				BestScoreText.text = "Best: " + bestScore.ToString ();
			}

		} else if (SceneManager.GetActiveScene ().buildIndex == 2) {
			if (bestScore1 < Score) {
				PlayerPrefs.SetInt ("Best1", Score);
				bestScore1 = Score;
				BestScoreText.text ="Best: " + bestScore1.ToString();

			}
			BestScoreText.text = "Best: " + bestScore1.ToString ();
		}



	
		ScoreText.text = "Score: " + Score.ToString();


		gameOver.gameObject.SetActive (true);
		pauseButton.gameObject.SetActive (false);
		foreach(Button button in buttons){
			button.gameObject.SetActive(true);
		}

	}

}
