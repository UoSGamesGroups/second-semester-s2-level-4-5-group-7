using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    private GameObject parentObj;

    public GameObject asteroidprefab1;
    public GameObject asteroidprefab2;
    public GameObject asteroidprefab3;
    public int maxAsteroids = 30;
    public int minAsteroids = 15;
    public GameObject[] asteroidArr;

    public float MaxPosition = 19f;

    public float minSize = 1f;
    public float MaxSize = 2f;

    // Use this for initialization
    void Start()
    {

        parentObj = gameObject;
        asteroidArr = new GameObject[maxAsteroids];//initialise an array to store all asteroid objects
        for (int i = 0; i < maxAsteroids; i++)
        {
            int randAst = Random.Range(0, 3);
            float randomSize = Random.Range(minSize, MaxSize);//random scale number for localscale

       
            if (randAst == 0)
            {
                GameObject asteroid = Instantiate(asteroidprefab1, new Vector3(Random.Range(-MaxPosition, MaxPosition), Random.Range(-MaxPosition, MaxPosition), 0), Quaternion.identity) as GameObject;/*instantiate game object with a random x,y*/
                asteroid.transform.localScale = new Vector3(randomSize, randomSize, 0);//random x,y scale between 1 and 2 (floating point numbers)
                asteroid.GetComponent<Rigidbody2D>().mass = randomSize;
                asteroid.transform.parent = parentObj.transform;
                asteroidArr[i] = asteroid;//assign position in array
            }
           else if (randAst == 1)
            {
                GameObject asteroid = Instantiate(asteroidprefab2, new Vector3(Random.Range(-MaxPosition, MaxPosition), Random.Range(-MaxPosition, MaxPosition), 0), Quaternion.identity) as GameObject;/*instantiate game object with a random x,y*/
                asteroid.transform.localScale = new Vector3(randomSize, randomSize, 0);//random x,y scale between 1 and 2 (floating point numbers)
                asteroid.GetComponent<Rigidbody2D>().mass = randomSize;
                asteroid.transform.parent = parentObj.transform;
                asteroidArr[i] = asteroid;//assign position in array
            }
          else  if (randAst == 2)
            {
                GameObject asteroid = Instantiate(asteroidprefab3, new Vector3(Random.Range(-MaxPosition, MaxPosition), Random.Range(-MaxPosition, MaxPosition), 0), Quaternion.identity) as GameObject;/*instantiate game object with a random x,y*/
                asteroid.transform.localScale = new Vector3(randomSize, randomSize, 0);//random x,y scale between 1 and 2 (floating point numbers)
                asteroid.GetComponent<Rigidbody2D>().mass = randomSize;
                asteroid.transform.parent = parentObj.transform;
                asteroidArr[i] = asteroid;//assign position in array
            }
        }  
    }//start() end
    private GameObject findSpareAsteroid()
    {
        for (int  i= 0; i < maxAsteroids; i++)
        {
            float randomSize = Random.Range(minSize, MaxSize);
            if(asteroidArr != null)
            {
                if(asteroidArr[i].activeSelf == false)
                {
                    asteroidArr[i].transform.rotation = Quaternion.identity;
                    asteroidArr[i].transform.position = new Vector2(Random.Range(-MaxPosition, MaxPosition), Random.Range(-MaxPosition, MaxPosition));
                    asteroidArr[i].transform.localScale = new Vector2(randomSize, randomSize);
                    asteroidArr[i].SetActive(true);
                    return asteroidArr[i];
                }
            }
        }
        return null;
    }
    void Update()
    {
        int currentAsteroids = 0;
        for(int i = 0; i < maxAsteroids; i++ )
        {
            if(asteroidArr[i].activeSelf == true)
            {
                currentAsteroids++;
            }
        }
        if(currentAsteroids < minAsteroids)
        {
            for(int i = 0; i < maxAsteroids - currentAsteroids; i++)
            {
                findSpareAsteroid();
            }
        }
    }
}
    

           
        
    

