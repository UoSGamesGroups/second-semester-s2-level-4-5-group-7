using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour
{
    private GameObject parentObj;

    #region asteroid prefabs
    public GameObject asteroidprefab1;
    public GameObject asteroidprefab2;
    public GameObject asteroidprefab3;
    public GameObject asteroidprefab4;
    public GameObject asteroidprefab5;
    public GameObject asteroidprefab6;
    public GameObject asteroidprefab7;
    public GameObject asteroidprefab8;
    public GameObject asteroidprefab9;
    public GameObject asteroidprefab10;
    #endregion asteroid prefabs



    private GameObject asteroidprefab;


    public int maxAsteroids = 60;
    public int minAsteroids = 30;
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
            int randAst = Random.Range(0, 10);
            float randomSize = Random.Range(minSize, MaxSize);//random scale number for localscale       
       
            switch(randAst)
            {
                case 0:
                    asteroidprefab = asteroidprefab1;
                    break;
                case 1:
                    asteroidprefab = asteroidprefab2;
                    break;
                case 2:
                    asteroidprefab = asteroidprefab3;
                    break;
                case 3:
                    asteroidprefab = asteroidprefab4;
                    break;
                case 4:
                    asteroidprefab = asteroidprefab5;
                    break;
                case 5:
                    asteroidprefab = asteroidprefab6;
                    break;
                case 6:
                    asteroidprefab = asteroidprefab7;
                    break;
                case 7:
                    asteroidprefab = asteroidprefab8;
                    break;
                case 8:
                    asteroidprefab = asteroidprefab9;
                    break;
                case 9:
                    asteroidprefab = asteroidprefab10;
                    break;
            }

                GameObject asteroid = Instantiate(asteroidprefab, new Vector3(Random.Range(-MaxPosition, MaxPosition), Random.Range(-MaxPosition, MaxPosition), 0), Quaternion.identity) as GameObject;/*instantiate game object with a random x,y*/
                asteroid.transform.localScale = new Vector3(randomSize, randomSize, 0);//random x,y scale between 1 and 2 (floating point numbers)
                asteroid.GetComponent<Rigidbody2D>().mass = randomSize;
                asteroid.transform.parent = parentObj.transform;
                asteroidArr[i] = asteroid;//assign position in array
        }  
    }//start() end
    private GameObject findSpareAsteroid()
    {
       int side = Random.Range(0, 4);
        Vector2 position = new Vector2(0f,0f);

        for (int  i= 0; i < maxAsteroids; i++)
        {

            //choose a random side for the asteroids to spawn on
            //L
            if(side == 0)
            {
            position = new Vector2 (Random.Range(-40,-35),Random.Range(-18,18));
            }
            //R
            else if (side == 1)
            {
                position = new Vector2(Random.Range(35, 40), Random.Range(-18, 18));
            }
            //T
            else if (side == 2)
            {
                position = new Vector2(Random.Range(-29, 29), Random.Range(20, 23));
            }
            //B
            else if (side == 3)
            {
                position = new Vector2(Random.Range(-29, 29), Random.Range(-20, -23));
            }

            float randomSize = Random.Range(minSize, MaxSize);
            if(asteroidArr != null)
            {
                if(asteroidArr[i].activeSelf == false)
                {
                    asteroidArr[i].transform.position = position;
                    asteroidArr[i].transform.localScale = new Vector2(randomSize, randomSize);
                    asteroidArr[i].SetActive(true);
                    //target-pos to get the desired velocity 
                    asteroidArr[i].GetComponent<Rigidbody2D>().velocity = new Vector2((1-asteroidArr[i].transform.position.x ),(1 - asteroidArr[i].transform.position.y)).normalized;
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

    

           
        
    

