using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    private GameObject parentObj;

    public GameObject asteroidprefab1;
    public GameObject asteroidprefab2;
    public GameObject asteroidprefab3;
    private int maxAsteroids = 30;
    private GameObject[] asteroidArr;



    // Use this for initialization
    void Start()
    {
        parentObj = gameObject;
        asteroidArr = new GameObject[maxAsteroids];//initialise an array to store all asteroid objects
        for (int i = 0; i < maxAsteroids; i++)
        {
            int randAst = Random.Range(0, 2);
            float randomSize = Random.Range(1f, 2f);//random scale number for localscale

       
            if (randAst == 0)
            {
                GameObject asteroid = Instantiate(asteroidprefab1, new Vector3(Random.Range(-19f, 19f), Random.Range(-19f, 19f), 0), Quaternion.identity) as GameObject;/*instantiate game object with a random x,y*/
                asteroid.transform.localScale = new Vector3(randomSize, randomSize, 0);//random x,y scale between 1 and 2 (floating point numbers)
                asteroid.GetComponent<Rigidbody2D>().mass = randomSize;
                asteroid.transform.parent = parentObj.transform;
                asteroidArr[i] = asteroid;//assign position in array
            }
           else if (randAst == 1)
            {
                GameObject asteroid = Instantiate(asteroidprefab2, new Vector3(Random.Range(-19f, 19f), Random.Range(-19f, 19f), 0), Quaternion.identity) as GameObject;/*instantiate game object with a random x,y*/
                asteroid.transform.localScale = new Vector3(randomSize, randomSize, 0);//random x,y scale between 1 and 2 (floating point numbers)
                asteroid.GetComponent<Rigidbody2D>().mass = randomSize;
                asteroid.transform.parent = parentObj.transform;
                asteroidArr[i] = asteroid;//assign position in array
            }
          else  if (randAst == 2)
            {
                GameObject asteroid = Instantiate(asteroidprefab3, new Vector3(Random.Range(-19f, 19f), Random.Range(-19f, 19f), 0), Quaternion.identity) as GameObject;/*instantiate game object with a random x,y*/
                asteroid.transform.localScale = new Vector3(randomSize, randomSize, 0);//random x,y scale between 1 and 2 (floating point numbers)
                asteroid.GetComponent<Rigidbody2D>().mass = randomSize;
                asteroid.transform.parent = parentObj.transform;
                asteroidArr[i] = asteroid;//assign position in array
            }
        }
    }
}
    

           
        
    

