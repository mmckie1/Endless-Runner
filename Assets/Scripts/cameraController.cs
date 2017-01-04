using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

	public playerContoller thePlayer;

	private Vector3 lastPlayerPositon;
	private float distanceToMove;

	// Use this for initialization
	void Start () {
	
		thePlayer = FindObjectOfType<playerContoller> ();
		lastPlayerPositon = thePlayer.transform.position;

	}
	
	// Update is called once per frame
	void Update () {

		distanceToMove = thePlayer.transform.position.x - lastPlayerPositon.x;

		transform.position = new Vector3 (transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		lastPlayerPositon = thePlayer.transform.position;
	
	}
}
