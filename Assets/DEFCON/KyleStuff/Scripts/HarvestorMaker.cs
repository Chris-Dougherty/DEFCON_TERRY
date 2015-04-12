using UnityEngine;
using System.Collections;

public class HarvestorMaker : MonoBehaviour 
{
	public GameObject HUnit;

	public int HCost = 300;
	
	public GameObject IncomeMan;

	// Use this for initialization
	void Start () 
	{
		IncomeMan = GameObject.FindGameObjectWithTag("IncomeManager");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	public void SpawnHUnit()
	{
		if (IncomeMan.GetComponent<Income>().income >= 0 + HCost)
		{
			GameObject clone;
			clone = Instantiate(HUnit, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1), Quaternion.identity) as GameObject;
			IncomeMan.GetComponent<Income>().Spend(HCost);
		}
	}

}
