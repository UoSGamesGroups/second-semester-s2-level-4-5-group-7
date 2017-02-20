﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroidSpawner : MonoBehaviour {
    private GameObject parentObj;
    public GameObject asteroidprefab;
    private int maxAsteroids = 30;
    private GameObject[] asteroidArr;

    public Sprite asteroidv1;
    public Sprite asteroidv2;
    public Sprite asteroidv3;


    // Use this for initialization
    void Start() {
        parentObj = gameObject;

        asteroidArr = new GameObject[maxAsteroids];//initialise an array to store all asteroid objects
        for (int i = 0; i < maxAsteroids; i++)
        {
            int randomAstType = Random.Range(0, 2);
            float randomSize = Random.Range(1f, 2f);//random scale number for localscale
            GameObject asteroid = Instantiate(asteroidprefab, new Vector3(Random.Range(-19f, 19f), Random.Range(-19f, 19f), 0), Quaternion.identity) as GameObject;//instantiate game object with a random x,y
            asteroid.transform.localScale =new Vector3(randomSize ,randomSize,0);//random x,y scale between 1 and 2 (floating point numbers)
            asteroid.GetComponent<CircleCollider2D>().radius = randomSize*0.75f;
            asteroid.GetComponent<Rigidbody2D>().mass = randomSize;
            asteroid.transform.parent = parentObj.transform;
            asteroidArr[i] = asteroid;//assign position in array

            if (randomAstType == 0) asteroid.GetComponent<SpriteRenderer>().sprite = asteroidv1;
            if (randomAstType == 1) asteroid.GetComponent<SpriteRenderer>().sprite = asteroidv2;
            if (randomAstType == 2) asteroid.GetComponent<SpriteRenderer>().sprite = asteroidv3;
        }
    }
}

