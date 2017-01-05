using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundGenerator : MonoBehaviour {
    
    public objectPool backgroundPool;

    public void SpawnBackground (Vector3 startPosition){
        
        GameObject background = backgroundPool.GetPooledObject();
        background.transform.position = startPosition;
        background.SetActive(true);
        
    }
    
}
