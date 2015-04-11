using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GatheringScript : MonoBehaviour {
	int Health = 100;


	public bool HasItem = false;

	Vector3 StartPos;
	public NavMeshAgent agent;
	public GameObject DeadBodyResource;
	public GameObject HomeBase;

	public GameObject CameraIncome;

	void Start () {
		StartPos = new Vector3 (transform.position.x,transform.position.y,transform.position.z);
		agent = GetComponent<NavMeshAgent> ();
		HomeBase = GameObject.FindGameObjectWithTag ("HomeBase");
		DeadBodyResource = GameObject.FindGameObjectWithTag ("Resource");

		CameraIncome = Camera.main.gameObject;
	}

	void GoHome()
	{
	
		agent.SetDestination (HomeBase.transform.position);
	}

	void Gather()
	{

		agent.SetDestination (DeadBodyResource.transform.position);

	}


	// Update is called once per frame
	void Update () 
	{
		if (!HasItem) 		
			{
			Gather ();
			}

		if (HasItem)
			{
			GoHome ();
			}

	}

	void OnCollisionEnter(Collision c)
	{
		if (c.gameObject.tag == "HomeBase") 
		{
			if (HasItem)
			{
			CameraIncome.GetComponent<Income>().income += 5;
			HasItem = false;
			}
		}

		if (c.gameObject.tag == "Resource") 
		{
			HasItem = true;
		}
	}
}
