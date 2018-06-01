using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraContorl : MonoBehaviour {

	GameObject player;
	Vector3 offset;
	void Start () {
		player = FindObjectOfType<ControlPlayer>().gameObject;
		offset = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(player == null){
			new seen().ChangeScene("GameOver");
		}
		transform.position = player.transform.position - offset;
	}
}
