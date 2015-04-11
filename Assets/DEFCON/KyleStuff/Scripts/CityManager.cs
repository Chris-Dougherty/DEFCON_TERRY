/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CityManager : MonoBehaviour {

	bool CloneSpawned = false;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FollowCursor()
	{
		// Raycast to keep building clone on cursor
		if (CloneSpawned)
		{
			// Raycast
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "Ground")
				{
					Clone.transform.position = new Vector3(hit.point.x, 5.0f, hit.point.z);
				}
			}
		}
		if (CloneSpawnedR)
		{
			// Raycast
			Ray ray = camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.tag == "Ground")
				{
					Clone.transform.position = new Vector3(hit.point.x, 5.0f, hit.point.z);
				}
			}
		}
	}
}
*/