using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContorler : MonoBehaviour {

	bool Paused;
	bool won;
	public GameObject boss;
	public GameObject tp;
	public static int numScore;
	public static int numLife;
	// Use this for initialization
	void Start () {
		numScore = 0;
		numLife = 0;

		DontDestroyOnLoad(gameObject);	
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P)) {
			Paused = !Paused;
		}
		if (Paused) {
			Time.timeScale = 0;
			tp.SetActive(true);
			
		}
		else if (!Paused) {
			Time.timeScale = 1;
			tp.SetActive(false);
		}
		/*if (boss.gameObject.GetComponent<MoveBoss>() != null) {
			if (boss.gameObject.GetComponent<MoveBoss>().hpenemy <= 0) {
				tp.SetActive(true);
			}else {
				tp.SetActive(false);
			}
		}*/
	}
	/*else if (other.gameObject.GetComponent<MoveBoss>() != null)
            {
                other.gameObject.GetComponent<MoveBoss>().hpenemy -= damage;
                
            } */

}
