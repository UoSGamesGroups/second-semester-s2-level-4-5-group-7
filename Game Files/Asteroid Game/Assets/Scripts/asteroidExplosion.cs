using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidExplosion : MonoBehaviour {

    public GameObject asteroidPiece;
    private int asteroidPieceAmount = 4;
    

	// Use this for initialization
	void Start () {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        //instantiate asteroid x number of times
        if (collision.collider.tag == "rocketT2")
        {
            for (int i = 0; i < asteroidPieceAmount; i++)
            {
               
                GameObject asteroid = Instantiate(asteroidPiece, gameObject.transform.position, transform.rotation) as GameObject;
                //make the asteroid's scale equal to 1/3 of the original asteroid
                asteroid.transform.localScale = new Vector3((gameObject.transform.localScale.x / 3), (gameObject.transform.localScale.y / 3), (gameObject.transform.localScale.z / 3));
                //randomise velocity and give it mass equal to 1/4 of the original 
                asteroid.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0);
                asteroid.GetComponent<Rigidbody2D>().mass = gameObject.GetComponent<Rigidbody2D>().mass / 4;     
            }
            Destroy(gameObject);
        }
    }
}
