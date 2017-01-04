﻿using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public playerContoller thePlayer;
	private Vector3 playerStartPoint;

	private platformDestoryer[] platfromList;

	// Use this for initialization
	void Start () {
	
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RestartGame(){
		StartCoroutine ("RestartGameCo");
	}

	public IEnumerator RestartGameCo(){
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds(0.5f);

		platfromList = FindObjectsOfType<platformDestoryer> ();
		for(int i=0; i<platfromList.Length; i++){
			platfromList [i].gameObject.SetActive (false);
		}

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);
	}
}
