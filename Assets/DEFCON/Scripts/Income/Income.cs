using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Income : MonoBehaviour {
	public int income = 0;

	public Text IncomeText;

	// Use this for initialization
	void Start () 
	{
        income = 1000;
	} 

	//attach to money making sources
	public void Add(int resourceAmount)
	{
		income += resourceAmount;
	}

	//attach to any actions that cost resources
	public void Spend(int cost)
	{
		if (income >= cost)
            income -= cost;
	}

	// Update is called once per frame
	void Update () 
	{
		IncomeText.text = income.ToString ();
	}
}
