using UnityEngine;
using System.Collections;

public class Player1Fire : MonoBehaviour {
    public GameObject prefab;
    private GameObject currRocket;
    private int speed = 3;
	// Use this for initialization
	void Start () {
        currRocket = null;
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.RightControl))
        {
           GameObject rocket = Instantiate(prefab, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity) as GameObject;
           rocket.transform.rotation = this.transform.rotation;
            currRocket = rocket;
        }
        if (currRocket != null)
        {
            currRocket.GetComponent<Rigidbody2D>().AddForce(currRocket.transform.up * speed);  
        }
	}
}
