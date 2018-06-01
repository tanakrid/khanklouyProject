using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerBoss : MonoBehaviour {

	public GameObject Bullet, realBullet;
	float timeOut = 0, coolDown = 5 ,time = 0;
	public bool isSeen = false;


		void OnTriggerStay2D(Collider2D other)
	{
		// if (other.gameObject.CompareTag("Player")){
		// Debug.Log(Time.time);

		if(other.gameObject.CompareTag("Player")) {
			isSeen = true;	
			// Debug.Log("found");
		}
	}

		void OnTriggerExit2D(Collider2D other)
		{
			if (other.gameObject.CompareTag("Player")) isSeen = false;
		}
}
