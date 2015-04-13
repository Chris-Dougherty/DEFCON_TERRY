using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnClick()
	{

		if (gameObject.tag == "Dominate") 
		{
			Debug.Log ("NEXT LEVEL");
			Application.LoadLevel ("Defcon_1");

		} else if (gameObject.tag == "Withdraw") 
		{
			Debug.Log("QUIT");
				Application.Quit();
		}

	}


}
