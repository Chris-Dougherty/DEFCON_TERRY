using UnityEngine;
using System.Collections;

public class MapControl : MonoBehaviour
{

    public float ScrollMultiplier;
    public float ZoomMultiplier;

    public float ZoomMin;
    public float ZoomMax;

    void Scroll()
    {
        Vector3 newPos = transform.localPosition;

        newPos.z += (Input.GetAxis("Vertical") * ScrollMultiplier);

        newPos.x += (Input.GetAxis("Horizontal") * ScrollMultiplier);

        //// Keyboard Input
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //{
        //    newPos.z += ScrollMultiplier;
        //}
        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    newPos.z -= ScrollMultiplier;
        //}
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    newPos.x -= ScrollMultiplier;
        //}
        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    newPos.x += ScrollMultiplier;
        //}

        transform.localPosition = newPos;
    }

    void Zoom()
    {
        Vector3 newPos = transform.localPosition;

        newPos.y += (-Input.GetAxisRaw("Mouse ScrollWheel") * ZoomMultiplier);

        transform.localPosition = newPos;
    }

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update ()
    {
	    Scroll();
        Zoom();
	}
}
