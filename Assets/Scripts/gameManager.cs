using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;
    
    public Transform backgroundGenerator;
    private Vector3 backgroundStartPoint;
    private backgroundGenerator theBackgroundGenerator;

	public playerContoller thePlayer;
	private Vector3 playerStartPoint;

	private platformDestoryer[] platfromList;

	private scoreManager theScoreManger;

	public deathMenu theDeathMenu;

	// Use this for initialization
	void Start () {
	
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;
        
        backgroundStartPoint = backgroundGenerator.position;

		theScoreManger = FindObjectOfType<scoreManager>();
        
        theBackgroundGenerator = FindObjectOfType<backgroundGenerator>();
	}
	
	// Update is called once per frame
	void Update () {
	   if(transform.position.x == backgroundGenerator.postion.x){
           theBackgroundGenerator.SpawnBackground(new Vector3 ());
       }
	}

	public void RestartGame(){
		//StartCoroutine ("RestartGameCo");
		theScoreManger.scoreIncreasing = false;
		thePlayer.gameObject.SetActive(false);

		theDeathMenu.gameObject.SetActive(true);

	}

	public void Reset(){

		theDeathMenu.gameObject.SetActive(false);
		platfromList = FindObjectsOfType<platformDestoryer> ();
		for(int i=0; i<platfromList.Length; i++){
			platfromList [i].gameObject.SetActive(false);
		}

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive(true);

		theScoreManger.scoreCount = 0;
		theScoreManger.scoreIncreasing = true;
	
	
	}

	/*public IEnumerator RestartGameCo(){
		theScoreManger.scoreIncreasing = false;
		thePlayer.gameObject.SetActive (false);
		yield return new WaitForSeconds(0.5f);

		platfromList = FindObjectsOfType<platformDestoryer> ();
		for(int i=0; i<platfromList.Length; i++){
			platfromList [i].gameObject.SetActive (false);
		}

		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;
		thePlayer.gameObject.SetActive (true);

		theScoreManger.scoreCount = 0;
		theScoreManger.scoreIncreasing = true;
	}*/
}
