using UnityEngine;
using System.Collections;

public class RocketExplosion : MonoBehaviour
{

    private float maxExplosionRadius = 8.0f;
    private GameObject rocket;
    private bool explosion;

    // Use this for initialization
    void Start()
    {
        //    rocket = this.gameObject;
        explosion = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (explosion && GetComponent<CircleCollider2D>().radius <= maxExplosionRadius)
        {
            GetComponent<CircleCollider2D>().radius += 0.2f;
        }
        if (GetComponent<CircleCollider2D>().radius >= maxExplosionRadius) Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //    if(collision.tag == "Meteor")
        explosion = true;
        Debug.Log("Explosion: " + explosion);
    }
}
