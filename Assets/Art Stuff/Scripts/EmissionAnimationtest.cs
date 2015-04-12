using UnityEngine;
using System.Collections;

public class EmissionAnimationtest : MonoBehaviour {
	


	void Update ()
	{	
		//YAY i am a programmer now! - Chris 
		Renderer renderer = GetComponent<Renderer>();
		Material[] mat = renderer.materials;
		float emission = Mathf.PingPong (Time.time, 1.0f);
		Color baseColor = Color.white; //Default
		Color finalColor = baseColor * Mathf.LinearToGammaSpace (emission);

		foreach (Material mats in mat)  // if there is more then one Material:
		{
			mats.SetColor ("_EmissionColor", finalColor);
		}
	}
}
