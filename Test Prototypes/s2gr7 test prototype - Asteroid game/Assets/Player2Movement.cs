using UnityEngine;
using System.Collections;

public class Player2Movement : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}
    public float speed = 0.1F;
    public float rotationSpeed = 100.0F;
    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            transform.Rotate(0, 0, rotation);
        }
        if (Input.GetKey("w") || Input.GetKey("s"))
        {
            transform.Translate(0, translation, 0);

        }
    }
}
