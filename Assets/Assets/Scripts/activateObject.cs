using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateObject : MonoBehaviour {

	public GameObject tree;
	public GameObject obj_0;
	public GameObject obj_1;
	public GameObject obj_2;
	public GameObject obj_3;
	public GameObject obj_4;
	public GameObject obj_5;
	public GameObject obj_6;

	public float maxSize; 	       //the biggest the objects will grow
    public float growFactor;       //how fast the objects change size
    public float waitTime; 		   //how long to activate tree
	public int undulationWaitTime; //how long till objects freak out

	void OnTriggerEnter(Collider other) {
		StartCoroutine(waitToActivate());

	}

	void Start() {
		//StartCoroutine(waitToActivate());
	}

	void Update() {
		//StartCoroutine(waitToActivate());
	}

    IEnumerator waitToActivate() {
    	yield return new WaitForSeconds(waitTime); //wait to activate tree

    	tree.SetActive(true); //activate tree

    	yield return new WaitForSeconds(undulationWaitTime); //wait to activate undulation

    	float timer = 0;
 
	    while(true) { // this could also be a condition indicating "alive or dead"
	        // we scale all axis, so they will have the same value, 
	        // so we can work with a float instead of comparing vectors
	        while(maxSize > obj_0.transform.localScale.x) {
	            timer += Time.deltaTime;
	            obj_0.transform.localScale += obj_0.transform.localScale * Time.deltaTime * growFactor;
	            obj_1.transform.localScale += obj_1.transform.localScale * Time.deltaTime * growFactor;
	            obj_2.transform.localScale += obj_2.transform.localScale * Time.deltaTime * growFactor;
	            obj_3.transform.localScale += obj_3.transform.localScale * Time.deltaTime * growFactor;
	            obj_4.transform.localScale += obj_4.transform.localScale * Time.deltaTime * growFactor;
	            obj_5.transform.localScale += obj_5.transform.localScale * Time.deltaTime * growFactor;
	            obj_6.transform.localScale -= obj_6.transform.localScale * Time.deltaTime * growFactor;
	            yield return null;
	        }
	        // reset the timer

	        yield return new WaitForSeconds(waitTime);

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
	            yield return null;
	        }

	        timer = 0;
	        yield return new WaitForSeconds(waitTime);
	    }
	}
}