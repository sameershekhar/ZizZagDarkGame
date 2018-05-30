using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {

	public AdManager admgr;
	public void PlayGameLevel1(){
		
		SceneManager.LoadScene (1);
	}
	public void PlayGameLevel2(){
		//admgr.ShowAds (2);
		SceneManager.LoadScene (2);
	}
	

	public void PlayLevel1(){
		SceneManager.LoadScene (1);
	}
	public void PlayLevel2(){
		SceneManager.LoadScene (2);
	}

	public void QuitGame () {
		Application.Quit ();
	}

	public void MainMenu()
	{
		SceneManager.LoadScene (0);
	}

	public void Store()
	{
		SceneManager.LoadScene (3);
	}


	public void PauseGame(){
		if (Time.timeScale == 1)
			Time.timeScale = 0;
		else if (Time.timeScale == 0)
			Time.timeScale = 1;
	}
}
