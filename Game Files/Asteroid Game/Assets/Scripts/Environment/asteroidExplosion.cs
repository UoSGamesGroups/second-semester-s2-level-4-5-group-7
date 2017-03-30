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

    private static float duration = 0.5f;
    private static float magnitude = 0.5f;

    // Use this for initialization
    void Start () {
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "p1Rocket"|| collision.collider.tag == "p2Rocket")
        {
            StartCoroutine(Shake());
        }



        //instantiate 4 smaller asteroids with less mass and a random velocity
        if (collision.collider.tag == "p1rocketT2"|| collision.collider.tag == "p2rocketT2")
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
           // Camera.main.transform.position = new Vector3(0, 0, -10);
        }
    }
    IEnumerator Shake()//ref  - http://unitytipsandtricks.blogspot.co.uk/2013/05/camera-shake.html
    {

        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float y = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            y *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        Camera.main.transform.position = originalCamPos;
    }
}
