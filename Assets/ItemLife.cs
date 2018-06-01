using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLife : MonoBehaviour {
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
		if(other.tag == "Player"){
			Text tt;
			tt = GameObject.Find("/Canvas showVeiw/Life").GetComponent<Text>();
			GameContorler.numLife++;
			tt.text = "Life: " + GameContorler.numLife;

			new Sound().SoundFX(sound, gameObject.transform.position);
			Destroy(gameObject);
		}

	}
}
