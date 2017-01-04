using UnityEngine;
using System.Collections;

public class platformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;

	public float distanceBetweenhMin;
	public float distanceBetweenMax;

	//public GameObject[] thePlatforms;
	public objectPool[] theObjectPools;
	private int platformSelector;
	private float[] platformWidths;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;

	public float maxHeightChange;
	private float heightChange;

	private coinGenerator theCoinGenerator; 
	public float randomCoinThreshold;

	// Use this for initialization
	void Start () {

		//platformWidth = thePlatform.GetComponent<BoxCollider2D> ().size.x;
		platformWidths = new float[theObjectPools.Length];

		for (int i=0; i<theObjectPools.Length; i ++){
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D> ().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theCoinGenerator = FindObjectOfType<coinGenerator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < generationPoint.position.x) {

			distanceBetween = Random.Range (distanceBetweenhMin, distanceBetweenMax);

			platformSelector = Random.Range (0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if(heightChange > maxHeight){

				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, heightChange,transform.position.z);
		

			//Instantiate (thePlatforms[platformSelector], transform.position, transform.rotation);
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive(true);

			if (Random.Range (0f, 100f) < randomCoinThreshold) {

				theCoinGenerator.SpawnCoin (new Vector3 (transform.position.x, transform.position.y + 1f, transform.position.z));
			}
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2), heightChange,transform.position.z);


		}
	
	}
}
