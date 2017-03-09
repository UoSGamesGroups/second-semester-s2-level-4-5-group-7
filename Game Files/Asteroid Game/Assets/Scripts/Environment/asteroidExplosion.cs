using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidExplosion : MonoBehaviour {


    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject asteroid4;
    public GameObject asteroid5;
    public GameObject asteroid6;
    public GameObject asteroid7;
    public GameObject asteroid8;

    private GameObject asteroidPiece;
    

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
                int randAst = Random.Range(0, 8);

                switch(randAst)
                {
                    case 0:
                        asteroidPiece = asteroid1;
                        break;
                    case 1:
                        asteroidPiece = asteroid2;
                        break;
                    case 2:
                        asteroidPiece = asteroid3;
                        break;
                    case 3:
                        asteroidPiece = asteroid4;
                        break;
                    case 4:
                        asteroidPiece = asteroid5;
                        break;
                    case 5:
                        asteroidPiece = asteroid6;
                        break;
                    case 6:
                        asteroidPiece = asteroid7;
                        break;
                    case 7:
                        asteroidPiece = asteroid8;
                        break;
                
                }

                GameObject asteroid = Instantiate(asteroidPiece, gameObject.transform.position, transform.rotation) as GameObject;
                asteroid.transform.localScale = new Vector3((gameObject.transform.localScale.x), (gameObject.transform.localScale.y), (gameObject.transform.localScale.z));
                asteroid.GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0);
                asteroid.GetComponent<Rigidbody2D>().mass = gameObject.GetComponent<Rigidbody2D>().mass / 4;     
            }
            gameObject.SetActive(false);
        }
    }
}
