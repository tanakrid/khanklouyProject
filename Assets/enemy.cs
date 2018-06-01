using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour {

	Rigidbody2D en;
	public bool walkRight;

	private Vector3 spwanPosition;

	private Vector2 playerPosition;
	
	public float startWalk;
	Vector3 eni;
	public float distance = 1.0f;

	public bool isFoundPlayer = false;

	private float currentPlayer;
	public float hpenemy;
    public float max = 100;
    public Image img;
	private float widthImg;


	void Start () {
		en = GetComponent<Rigidbody2D>();
		walkRight = true;
		spwanPosition = gameObject.transform.position;
		currentPlayer = en.transform.position.x;
		Debug.Log(name); 	
		widthImg =  img.GetComponent<RectTransform>().sizeDelta.x;
        hpenemy = 100;
	}
	

	void Update () {
		
		if (hpenemy <= 0) {
			Destroy(gameObject);
        }
		img.GetComponent<RectTransform>().sizeDelta = new Vector2( (hpenemy / max) * widthImg,img.GetComponent<RectTransform>().sizeDelta.y );
		float jump = 0f;

		if (spwanPosition.x + startWalk <= gameObject.transform.position.x || playerPosition.x - en.transform.position.x < 1){
			walkRight = false;
			distance = -1;
		}

		else if (spwanPosition.x - startWalk >= gameObject.transform.position.x  ||playerPosition.x - en.transform.position.x >= 1){
			walkRight = true;
			distance = 1;
		}

		if(isFoundPlayer && Mathf.Abs(currentPlayer - en.transform.position.x) >= 0.01f){
			jump = 10.0f * Time.deltaTime;
		}
		en.transform.Translate(new Vector3(5.0f * Time.deltaTime * distance, jump));
		currentPlayer = en.transform.position.x;
		
		// 	eni.x = en.transform.position.x;
		// 	en.transform.Translate(new Vector3(10.0f * Time.deltaTime, 0f));
		// 	if (Mathf.Abs(en.transform.position.x)-Mathf.Abs(eni.x) > distance * 1) {
		// 		walkRight = false;
		// 	}
		// }else {
		// 	eni.x = en.transform.position.x;
		// 	en.transform.Translate(new Vector3(-10.0f * Time.deltaTime, 0f));
		// 	if (Mathf.Abs(en.transform.position.x)-Mathf.Abs(eni.x) > distance * 1) {
		// 		walkRight = false;
		// 	}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player") {
			isFoundPlayer = true;
			playerPosition = other.transform.position;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Player") {
			isFoundPlayer = true;
			playerPosition = other.transform.position;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player") {
			isFoundPlayer = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.CompareTag("Player")) {
			ControlPlayer.hpplayer -= 5;
			hpenemy -= 20;
		}
	}
}
