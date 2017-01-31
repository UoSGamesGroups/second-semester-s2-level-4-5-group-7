using UnityEngine;
using System.Collections;

public class Sling : MonoBehaviour {
    bool Selected = false;

    float TargetZ;



    public float MouseX;
    public float MouseY;
    public float XDifference;
    public float YDifference;
    public float TargetZAngle;
    public float AngleCalculation;
    public float Multiplier;




    public Rigidbody2D RigBod;










    // Use this for initialization
    void Start () {
        TargetZ = transform.rotation.z;
        RigBod = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        TargetZAngle = TargetZ;
        transform.rotation = Quaternion.Slerp(transform.rotation, new Quaternion(transform.rotation.x, transform.rotation.y,TargetZ, transform.rotation.w), 10);
    }

    void OnMouseDown()
    {
        Selected = true;
    }

    void OnMouseDrag()
    {
        Vector3 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MouseX = MousePos.x;
        MouseY = MousePos.y;



        float XDif = -transform.position.x + MousePos.x;
        float YDif = -transform.position.y + MousePos.y;
        XDifference = XDif;
        YDifference = YDif;

        float Angle = Mathf.Atan(YDif / XDif);

        TargetZ = Mathf.Deg2Rad * 90-Angle * Multiplier;
        AngleCalculation = Angle ;
    }

    void OnMouseUp() {
        if (Selected)
        {
            float Force = -40;
            Selected = false;
            RigBod.AddForce(new Vector2(Force * Mathf.Cos(AngleCalculation), Force * Mathf.Sin(AngleCalculation)));
            //find coordinates
        }
    }
}
