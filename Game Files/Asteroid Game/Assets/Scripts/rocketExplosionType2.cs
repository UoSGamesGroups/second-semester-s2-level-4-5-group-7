using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketExplosionType2 : MonoBehaviour {
    private int maxExplosionRadius = 4;
    public bool explode;

	// Use this for initialization
	void Start () {
        explode = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(explode && gameObject.GetComponent<CircleCollider2D>().radius < maxExplosionRadius)
        {
            gameObject.GetComponent<CircleCollider2D>().radius += 0.1f;
        }
        if(gameObject.GetComponent<CircleCollider2D>().radius>= maxExplosionRadius)
        {
            Destroy(gameObject);
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "asteroid")
        {
            explode = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
