using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBoss : MonoBehaviour
{
    public AudioClip sound;
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
    public float max = 2000;
    public Image img;
    private float widthImg;
    public GameObject bullet, realBullet;
    float timeOut = 0, coolDown = 5;
    public bool won;



    void Start()
    {
        en = GetComponent<Rigidbody2D>();
        walkRight = true;
        spwanPosition = gameObject.transform.position;
        currentPlayer = en.transform.position.x;
        Debug.Log(name);
        widthImg = img.GetComponent<RectTransform>().sizeDelta.x;
        hpenemy = 1;
        won = false;
    }


    void Update()
    {

        // if (hpenemy <= 0) {
        // 	//Debug.Log("won");
        // 	new seen().ChangeScene("won");
        // 	Destroy(gameObject);
        // }
        img.GetComponent<RectTransform>().sizeDelta = new Vector2((hpenemy / (max * 20)) * widthImg, img.GetComponent<RectTransform>().sizeDelta.y);
        float jump = 0f;

        if (spwanPosition.x + startWalk <= gameObject.transform.position.x || playerPosition.x - en.transform.position.x < 1)
        {
            walkRight = false;
            distance = -1;
        }

        else if (spwanPosition.x - startWalk >= gameObject.transform.position.x || playerPosition.x - en.transform.position.x >= 1)
        {
            walkRight = true;
            distance = 1;
        }

        if (isFoundPlayer && Mathf.Abs(currentPlayer - en.transform.position.x) >= 0.01f)
        {
            jump = 10.0f * Time.deltaTime;
        }
        en.transform.Translate(new Vector3(5.0f * Time.deltaTime * distance, jump));
        currentPlayer = en.transform.position.x;

        Debug.Log(Time.time);
        if (Time.time > timeOut + coolDown)
        {
            Debug.Log("shoot");
            new Sound().SoundFX(sound, gameObject.transform.position);
            realBullet = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
            realBullet.GetComponent<Bullet>().player = gameObject;
            realBullet.GetComponent<Bullet>().setDamage(50f);
            realBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(50f * distance, 0f);
            realBullet.GetComponent<SpriteRenderer>().flipX = distance < 0;
            Destroy(realBullet, 7);
            timeOut = Time.time;
        }

        // if (hpenemy == 0) {
        // 		new seen().ChangeScene("GameOver");
        // 	}

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isFoundPlayer = true;
            playerPosition = other.transform.position;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isFoundPlayer = true;
            playerPosition = other.transform.position;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isFoundPlayer = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ControlPlayer.hpplayer -= 10;
            //hpenemy -= 20;
        }
        // else if (other.gameObject.CompareTag("bullet"))
        // {
        //     if (hpenemy <= 0)
        //     {
        //         new seen().ChangeScene("won");
        //     }
        //}
    }
}