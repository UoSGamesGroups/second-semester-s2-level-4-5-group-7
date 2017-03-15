using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocketExplosionType2 : MonoBehaviour {
    private int maxExplosionRadius = 4;
    public bool explode;
    public Animator animation;

	// Use this for initialization
	void Start () {
        explode = false;
        animation = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(explode && gameObject.GetComponent<CircleCollider2D>().radius < maxExplosionRadius)
        {
            gameObject.GetComponent<CircleCollider2D>().radius += 0.1f;
        }
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "asteroid")
        {
            explode = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(waitForAnim());
        }
    }
    IEnumerator waitForAnim()
    {
        animation.SetBool("Explode", true);
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        animation.SetBool("Explode", false);
    }
}
