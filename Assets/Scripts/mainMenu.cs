﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour {


	public string playGameLevel;


	public void PlayGame(){

		SceneManager.LoadScene(playGameLevel);

	}

	public void QuitGame(){
		Application.Quit ();
	
	}


}
