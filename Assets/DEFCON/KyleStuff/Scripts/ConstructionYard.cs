using UnityEngine;
using System.Collections;

public class ConstructionYard : MonoBehaviour 
{

	// Units building spawns
	public GameObject Unit;
	public GameObject AirUnit;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SpawnUnit()
	{
		GameObject clone;
		clone = Instantiate(Unit, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 8), Quaternion.identity) as GameObject;
	}
	
	public void SpawnAirUnit()
	{
		GameObject clone;
		clone = Instantiate(AirUnit, new Vector3(this.transform.position.x, this.transform.position.y + 10, this.transform.position.z - 8), Quaternion.identity) as GameObject;
	}
}
