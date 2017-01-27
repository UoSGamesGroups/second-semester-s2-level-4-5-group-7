using UnityEngine;
using System.Collections;

public class spawnAsteroids : MonoBehaviour {

    public GameObject prefab;
	// Use this for initialization
	void Start () {
	
        for(int i = 0;i<30;i++)
        {
            Instantiate(prefab,new Vector3(Random.Range(-18f,18f),Random.Range(-18,18),0),Quaternion.identity);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
