using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeRooms : MonoBehaviour {

	public GameObject starTunnel;
	public GameObject redRoom;

	void OnTriggerEnter(Collider other) {
		starTunnel.SetActive(false);
		redRoom.SetActive(true);
	}

}
