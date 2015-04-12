using UnityEngine;
using System.Collections;

public class ResourceNode : MonoBehaviour {

	public int NodeHealth = 10;
	Vector3 StartPos;
	//public NavMeshAgent Agent;
	//public GameObject Node;

	// Use this for initialization
	void Start () {
		StartPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
	}

	public void Depleted ()
	{
		NodeHealth -= 1;
		if (NodeHealth <= 0)
			Destroy (this.gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
