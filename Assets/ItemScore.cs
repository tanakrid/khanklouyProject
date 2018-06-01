using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScore : MonoBehaviour {

	public AudioClip sound;
   	public AudioSource source;

	Collider2D c;
	// Use this for initialization
	void Start () {
		c = GetComponent<Collider2D>();
		c.isTrigger = true;
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player"){
			Text t;
			t = GameObject.Find("/Canvas showVeiw/Score").GetComponent<Text>();
			GameContorler.numScore += 10;
			t.text = "Score: " + GameContorler.numScore;
			
			new Sound().SoundFX(sound, gameObject.transform.position);
			Destroy(gameObject);
		
		}
	}
}
