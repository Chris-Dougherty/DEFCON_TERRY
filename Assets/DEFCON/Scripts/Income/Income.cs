using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Income : MonoBehaviour {
	public int income = 0;
	int incomeMax = 1000;
	int rateOfGain=1;

	public Text IncomeText;

	// Use this for initialization
	void Start () 
	{
	
	} 

	void Trickle()
	{
		if (income < incomeMax) 
		{
			//income += rateOfGain * Time.deltaTime;
		}
	}

	//attach to money making sources
	void Add(int resourceAmount)
	{
		income += resourceAmount;
	}

	//attach to any actions that cost resources
	void Spend(int cost)
	{
		income -= cost;
	}

	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.KeypadPlus))
			Add (5);

		if (Input.GetKeyDown (KeyCode.Minus))
			Spend (5);

		IncomeText.text = income.ToString ();
	}
}
