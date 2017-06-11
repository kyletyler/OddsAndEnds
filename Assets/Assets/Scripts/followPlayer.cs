using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour {

	public Transform target;
    public float speed;
    public float growthRate;

    void Start() {
    	
    }

    void Update() {
    	float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        transform.localScale += new Vector3(growthRate, growthRate, growthRate);
    }
}
