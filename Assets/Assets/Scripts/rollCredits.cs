using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollCredits : MonoBehaviour {

	public GameObject credits;

	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider other) { 
		credits.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
