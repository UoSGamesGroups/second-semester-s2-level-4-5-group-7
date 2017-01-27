using UnityEngine;
using System.Collections;

public class Player1Movement : MonoBehaviour {

   


    // Use this for initialization
    void Start ()
    {
    }

    // Update is called once per frame
    public float speed = 0.1f;
    public float rotationSpeed = 100.0F;
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey((KeyCode.DownArrow)))
        {
            transform.Translate(0, translation, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey((KeyCode.RightArrow)))
        {
            transform.Rotate(0, 0, rotation);
        }
       
    }
}
