using UnityEngine;
using System.Collections;

public class Cities : MonoBehaviour {

    public int Population;
    
    public TextMesh PopText;

	// Use this for initialization
	void Start () 
    {
        Population = Random.Range(1000000, 5000000);
	}
	
	// Update is called once per frame
	void Update () 
    {
        PopText.text = Population.ToString();
	}

    void LosePopulation(int taken)
    {
        if(Population > 0)
            Population -= taken;
    }
}
