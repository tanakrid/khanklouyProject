using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontrol : MonoBehaviour {

	Rigidbody2D p;
	public bool Paused;
	bool jump = true;
	void Start () {
		p = GetComponent<Rigidbody2D>();
		Paused = false;
	}
	
	void Update () {

		jump = p.velocity.y == 0;

		if(Input.GetKey(KeyCode.RightArrow)) {
			p.transform.Translate(new Vector3(15f * Time.deltaTime, 0));
		}
		else if(Input.GetKey(KeyCode.LeftArrow)) {
			p.transform.Translate(new Vector3(-15f * Time.deltaTime, 0));
		}
		if(Input.GetKey(KeyCode.UpArrow) && jump) {
			p.velocity = new Vector2(0f,18f);
		}
	}

	void OnCollisionEnter2D(Collision2D coll)
    {
     //booster
        if (coll.gameObject.CompareTag("Booster")) {
			p.velocity = new Vector2(0f, 30f);
		}
        else if (coll.gameObject.CompareTag("Death")) {
			if (GameContorler.numLife == 0) {
				new seen().ChangeScene("GameOver");
			}
			else {
				gameObject.transform.position = new Vector3(-8f,10f,-5f);
				Text tt;
				tt = GameObject.Find("/Canvas showVeiw/Life").GetComponent<Text>();
				GameContorler.numLife--;
				tt.text = "Life = " + GameContorler.numLife;
				
			}
		}
		else if (coll.gameObject.CompareTag("ChangeSceneTummy")) {
			new seen().ChangeScene("Tum");
		}
		else if (coll.gameObject.CompareTag("ChangeSceneBosso")) {
			new seen().ChangeScene("Bosso");
		}
    }
}
