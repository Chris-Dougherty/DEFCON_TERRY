using UnityEngine;
using System.Collections;

public class ConstructionYard : MonoBehaviour 
{

	// Units building spawns
	public GameObject Unit;
	public GameObject AirUnit;
    public int TankCost = 100;
    public int PlaneCost = 200;

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

	public void SpawnUnit()
	{
        if (IncomeMan.GetComponent<Income>().income >= 0 + TankCost)
        {
            GameObject clone;
            clone = Instantiate(Unit, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - 1), Quaternion.identity) as GameObject;
            IncomeMan.GetComponent<Income>().Spend(TankCost);
        }
	}
	
	public void SpawnAirUnit()
	{
        if (IncomeMan.GetComponent<Income>().income >= 0 + PlaneCost)
        {
            GameObject clone;
            clone = Instantiate(AirUnit, new Vector3(this.transform.position.x, this.transform.position.y + 5, this.transform.position.z - 1), Quaternion.identity) as GameObject;
            IncomeMan.GetComponent<Income>().Spend(PlaneCost);
        }
	}
}
