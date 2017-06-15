using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disappearFloor : MonoBehaviour {

	public GameObject floor;
	public float timeTilDestroy;

	void OnTriggerEnter(Collider other) {
		StartCoroutine (startShrinking());
	}

	IEnumerator startShrinking(){
    	yield return new WaitForSeconds (timeTilDestroy);

        GetComponent<AudioSource>().Play();
        
        while(floor.transform.localScale.x >= 6.0f) 
        {
            yield return new WaitForSeconds (0.1f);
            floor.transform.localScale = floor.transform.localScale * 0.999f;
            floor.transform.Rotate (new Vector3 (-30, 0, 0) * Time.deltaTime);
        }

        GetComponent<AudioSource>().Stop();
    }
}
