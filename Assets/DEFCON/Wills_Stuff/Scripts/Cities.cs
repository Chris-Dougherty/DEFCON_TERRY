using UnityEngine;
using System.Collections;

public class Cities : MonoBehaviour {

    public int Population;
    
    public TextMesh PopText;

    public GameObject Model1;
    public GameObject Model2;

	// Use this for initialization
	void Start () 
    {
        Population = Random.Range(1000000, 5000000);
        Model1.SetActive(false);
        Model2.SetActive(false);
        if (Random.Range(0, 2) == 1)
            Model1.SetActive(true);
        else
            Model2.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () 
    {
        PopText.text = Population.ToString();
	}

    public void LosePopulation(int taken)
    {
        if (Population > 0)
            Population -= taken;

        if (Population <= 0)
            Population = 0;
    }
}
