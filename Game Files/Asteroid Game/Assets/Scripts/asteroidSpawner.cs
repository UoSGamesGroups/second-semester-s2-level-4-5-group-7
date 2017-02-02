using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour {
    private GameObject parentObj;
    public GameObject asteroidprefab;
    private int maxAsteroids = 30;
    private GameObject[] asteroidArr;
    // Use this for initialization
    void Start() {
        parentObj = gameObject;
        asteroidArr = new GameObject[maxAsteroids];//initialise an array to store all asteroid objects
        for (int i = 0; i < maxAsteroids; i++)
        {
            float randomSize = Random.Range(1f, 2f);//random scale number for localscale
            GameObject asteroid = Instantiate(asteroidprefab, new Vector3(Random.Range(-19f, 19f), Random.Range(-19f, 19f), 0), Quaternion.identity) as GameObject;//instantiate game object with a random x,y
            asteroid.transform.localScale =new Vector3(randomSize ,randomSize,0);//random x,y scale between 1 and 2 (floating point numbers)
            asteroid.transform.parent = parentObj.transform;
            asteroidArr[i] = asteroid;//assign position in array
        }
    }
}

