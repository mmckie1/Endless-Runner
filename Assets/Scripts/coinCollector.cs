using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollector : MonoBehaviour {

	public int scoreToGive;

	private scoreManager theScoreManager;
    
    private AudioSource coinSound;

	// Use this for initialization
	void Start () {

		theScoreManager = FindObjectOfType<scoreManager> ();
        
        coinSound = GameObject.Find ("CoinSound").GetComponent<AudioSource>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.name == "Player"){
			theScoreManager.AddScore(scoreToGive);
			gameObject.SetActive (false);
            
            coinSound.Play();
        
		}
	}
}
