using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidExplosion : MonoBehaviour {

    public GameObject asteroidPiece;
    

	// Use this for initialization
	void Start () {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //instantiate 4 smaller asteroids with less mass and a random velocity
        if (collision.collider.tag == "rocketT2")
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject asteroid = Instantiate(asteroidPiece, gameObject.transform.position, transform.rotation) as GameObject;
                asteroid.transform.localScale = new Vector3((gameObject.transform.localScale.x), (gameObject.transform.localScale.y), (gameObject.transform.localScale.z));
                asteroid.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0);
                asteroid.GetComponent<Rigidbody2D>().mass = gameObject.GetComponent<Rigidbody2D>().mass / 4;     
            }
            gameObject.SetActive(false);
        }
    }
}
