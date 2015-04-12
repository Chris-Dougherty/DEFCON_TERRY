using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GatheringScript : MonoBehaviour {
	int Health = 10;


	public bool HasItem = false;

	Vector3 StartPos;
	public NavMeshAgent Agent;
	public GameObject DeadBodyResource;
	public GameObject HomeBase;

	public GameObject CameraIncome;

	void Start () {
		StartPos = new Vector3 (transform.position.x,transform.position.y,transform.position.z);
		Agent = GetComponent<NavMeshAgent> ();
		HomeBase = GameObject.FindGameObjectWithTag ("HomeBase");
		DeadBodyResource = GameObject.FindGameObjectWithTag ("Resource");

		CameraIncome = Camera.main.gameObject;
	}

	void GoHome()
	{
	
		Agent.SetDestination (HomeBase.transform.position);
	}

	void Gather()
	{
		if (DeadBodyResource != null)
			Agent.SetDestination (DeadBodyResource.transform.position);

	}


	// Update is called once per frame
	void Update () 
	{
		if (!HasItem) 		
			Gather ();
			
		if (HasItem)
			GoHome ();
	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "HomeBase") 
		{
			if (HasItem)
			{
			CameraIncome.GetComponent<Income>().income += 1;
			HasItem = false;
			}
		}

		if (c.gameObject.tag == "Resource") 
		{
			c.gameObject.GetComponent<ResourceNode>().Depleted();
			HasItem = true;
		}
	}
}
