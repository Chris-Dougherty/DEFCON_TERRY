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

        // Keyboard Input
        if (Input.GetKey(KeyCode.UpArrow))
        {
            newPos.z += ScrollMultiplier;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            newPos.z -= ScrollMultiplier;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            newPos.x -= ScrollMultiplier;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            newPos.x += ScrollMultiplier;
        }

        transform.localPosition = newPos;
    }

    void Zoom()
    {
        Vector3 newPos = transform.localPosition;

        newPos.y += (Input.GetAxisRaw("Mouse ScrollWheel") * ZoomMultiplier);

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
