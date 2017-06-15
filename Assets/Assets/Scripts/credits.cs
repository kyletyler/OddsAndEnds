using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class credits : MonoBehaviour {

	public GameObject underworld;

	public float scrollSpeed;

	// Use this for initialization
	void Start () {
		StartCoroutine(endGame());
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3(0.0f, scrollSpeed, 0.0f);
	}

	 IEnumerator endGame() {
	 	yield return new WaitForSeconds(48);
	 
	 	//the following type of #if statement is used when you want to access compiler constants --- like UNITY_EDITOR

	 	for(float i = 0.0f; i <= 500.0f; i++) {
	 		yield return new WaitForSeconds(0.0001f);
	 		underworld.transform.position -= new Vector3(0.0f, 4.0f, 0.0f);
	 	}

	 	#if UNITY_EDITOR
	         // Application.Quit() does not work in the editor so
	         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
	         UnityEditor.EditorApplication.isPlaying = false;
    	 #else
         	Application.Quit();
     	#endif
     	
	 }
}
