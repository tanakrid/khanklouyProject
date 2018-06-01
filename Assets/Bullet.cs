using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{

    // Use this for initialization
    public GameObject player;
    private float damage;

    public void setDamage(float damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		

        if (player == other.gameObject || other.CompareTag("checkFound"))
            return;
        Debug.Log(other.name);
        if (other.tag == "enemy" || other.tag == "Player")
        {
            if (other.gameObject.GetComponent<enemy>() != null)
            {
                Debug.Log(other.gameObject.GetComponent<enemy>());
                Debug.Log("zzzzzzzzzzzzzz");
                other.gameObject.GetComponent<enemy>().hpenemy -= damage;
            }
            else if (other.gameObject.GetComponent<MoveBoss>() != null)
            {
                other.gameObject.GetComponent<MoveBoss>().hpenemy -= damage;
                
            }else if(other.gameObject.GetComponent<ControlPlayer>() != null){
                ControlPlayer.hpplayer -= damage;
            }
            // Debug.Log("fire");
            Destroy(gameObject);
        }
        else if (other.CompareTag("Obstacle"))
        {
            // Debug.Log("fire2");
            Destroy(gameObject);

            //Debug.Log("fire enemy");
        }
    }
}

/*public class Bullet : NetworkBehaviour {

    [SyncVar]
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject != player)
            Destroy(gameObject);
    }
}*/
