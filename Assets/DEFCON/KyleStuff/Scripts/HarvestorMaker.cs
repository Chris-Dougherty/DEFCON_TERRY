using UnityEngine;
using System.Collections;

public class HarvestorMaker : MonoBehaviour 
{
	public GameObject HUnit;
    public GameObject TPortUnit;

	public int HCost = 300;
    public int TPortCost = 750;

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
			clone = Instantiate(HUnit, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z - 1), Quaternion.identity) as GameObject;
			IncomeMan.GetComponent<Income>().Spend(HCost);
		}
	}

    public void SpawnTUnit()
    {
        if (IncomeMan.GetComponent<Income>().income >= 0 + TPortCost)
        {
            GameObject clone;
            clone = Instantiate(TPortUnit, new Vector3(this.transform.position.x, this.transform.position.y + 5, this.transform.position.z - 1), Quaternion.identity) as GameObject;
            IncomeMan.GetComponent<Income>().Spend(TPortCost);
        }
    }

}
