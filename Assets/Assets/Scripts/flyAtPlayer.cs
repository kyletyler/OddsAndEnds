using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyAtPlayer : MonoBehaviour {
	
	public Transform target;
    public float speed;
    public float dist;

    public GameObject me;
    public GameObject room;
    public GameObject underworld;
    
    void OnTriggerEnter(Collider other) {
    	Destroy(room);
    	underworld.SetActive(true);
    }

    void Update() {
    	float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
   
       dist = Vector3.Distance(target.position, transform.position);
       
       //if (dist <= 1) {
       	//transform.position += Vector3.MoveTowards(transform.position, target.position, step);
       //	Destroy(me);
    }


  



}
