using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateObject : MonoBehaviour {

	public GameObject tree;
	//public GameObject brain;
	public GameObject obj_0;
	public GameObject obj_1;
	public GameObject obj_2;
	public GameObject obj_3;
	public GameObject obj_4;
	public GameObject obj_5;
	public GameObject obj_6;
	public GameObject obj_7;
	public GameObject lights;
	public GameObject floodLight1;
	public GameObject floodLight2;
	public GameObject wall1;
	public GameObject wall2;
	public GameObject wall3;
	public GameObject wall4;
	public GameObject owl;

	//public Light lt1;
	//public Light lt2;

	public float maxSize; 	       //the biggest the objects will grow
    public float growFactor;       //how fast the objects change size
    //suggested val: 20
    public float secondsTilTree; 		   //how long to activate tree
	//suggested val: 15
	public int secondsTilObjectsMove; //how long till objects freak out
	//suggested val: 15
	public int secondsTilWallsFall;
	//suggested val: 5
	public int secondsTilOwl;

	private bool isTriggered = false;

	void Start() {
		//lt1 = GetComponent<Light>();
		//lt2 = GetComponent<Light>();
	}

	void OnTriggerEnter(Collider other) {
		if(isTriggered == false) { 
			isTriggered = true;
			StartCoroutine(waitToActivate());
		}
	}

    IEnumerator waitToActivate() {
    	yield return new WaitForSeconds(secondsTilTree); //wait to activate tree

    	tree.SetActive(true); //activate tree
    	//brain.SetActive(true);

    	yield return new WaitForSeconds(secondsTilObjectsMove); //wait to activate undulation

    	obj_0.GetComponent<AudioSource>().Play();

    	float timer = 0;
    	int timeSoFar = 0;

	    while(timeSoFar <= secondsTilWallsFall) { 
	      
	        while(maxSize > obj_0.transform.localScale.x) {
	            timer += Time.deltaTime;
	            obj_0.transform.localScale += obj_0.transform.localScale * Time.deltaTime * growFactor;
	            obj_1.transform.localScale += obj_1.transform.localScale * Time.deltaTime * growFactor;
	            obj_2.transform.localScale += obj_2.transform.localScale * Time.deltaTime * growFactor;
	            obj_3.transform.localScale += obj_3.transform.localScale * Time.deltaTime * growFactor;
	            obj_4.transform.localScale += obj_4.transform.localScale * Time.deltaTime * growFactor;
	            obj_5.transform.localScale += obj_5.transform.localScale * Time.deltaTime * growFactor;
	            obj_6.transform.localScale += obj_6.transform.localScale * Time.deltaTime * growFactor;
	            obj_7.transform.localScale += obj_7.transform.localScale * Time.deltaTime * growFactor;
	            lights.SetActive(false);
	            yield return null;
	        }

	        // reset the timer
	        timer = 0;
	        while(1 < obj_0.transform.localScale.x) {
	            timer += Time.deltaTime;
	            obj_0.transform.localScale -= obj_0.transform.localScale * Time.deltaTime * growFactor;
	            obj_1.transform.localScale -= obj_1.transform.localScale * Time.deltaTime * growFactor;
	            obj_2.transform.localScale -= obj_2.transform.localScale * Time.deltaTime * growFactor;
	            obj_3.transform.localScale -= obj_3.transform.localScale * Time.deltaTime * growFactor;
	            obj_4.transform.localScale -= obj_4.transform.localScale * Time.deltaTime * growFactor;
	            obj_5.transform.localScale -= obj_5.transform.localScale * Time.deltaTime * growFactor;
	            obj_6.transform.localScale -= obj_6.transform.localScale * Time.deltaTime * growFactor;
	            obj_7.transform.localScale -= obj_7.transform.localScale * Time.deltaTime * growFactor;
	            lights.SetActive(true);
	            yield return null;
	        }

	        timer = 0;
	        timeSoFar++;
	    }

	    floodLight1.SetActive(true);
	    floodLight2.SetActive(true);

	    for(int i = 0; i <= 200; i++) {
	    	yield return new WaitForSeconds(0.009f);
	    	floodLight1.GetComponent<Light>().intensity = i++;
	    	floodLight2.GetComponent<Light>().intensity = i++;
	    }

	    Destroy(tree);
	    Destroy(obj_0);
	    Destroy(obj_1);
	    Destroy(obj_2);
	    Destroy(obj_3);
	    Destroy(obj_4);
	    Destroy(obj_5);
	    Destroy(obj_6);
	    Destroy(obj_7);
	    Destroy(lights);

	     for(int i = 200; i >= 0; i--) {
	    	yield return new WaitForSeconds(0.009f);
	    	floodLight1.GetComponent<Light>().intensity = i--;
	    	floodLight2.GetComponent<Light>().intensity = i--;
	    }

	    Destroy(floodLight1);
	    Destroy(floodLight2);

	    while(wall3.transform.localPosition.z >= -450) {
        	yield return new WaitForSeconds (0.001f);
            wall1.transform.Rotate(Vector3.left * (Time.deltaTime * 8));
            wall1.transform.localPosition -= new Vector3 (0.0f, 26.0f, -28.0f) * Time.deltaTime;
            wall3.transform.Rotate(Vector3.left * (Time.deltaTime * 8));
            wall3.transform.localPosition -= new Vector3 (0.0f, 26.0f, 28.0f) * Time.deltaTime;
            wall2.transform.Rotate(Vector3.left * (Time.deltaTime * 8));
            wall2.transform.localPosition -= new Vector3 (-28.0f, 26.0f, 0.0f) * Time.deltaTime;
            wall4.transform.Rotate(Vector3.left * (Time.deltaTime * 8));
            wall4.transform.localPosition -= new Vector3 (28.0f, 26.0f, 0.0f) * Time.deltaTime;
        }

        wall1.SetActive(false);
        wall2.SetActive(false);
        wall3.SetActive(false);
        wall4.SetActive(false);
        owl.SetActive(true);
	}
}