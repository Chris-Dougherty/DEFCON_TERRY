using UnityEngine;
using System.Collections;


public class BasicTurret : MonoBehaviour {
	public int Health = 3;
	public Vector3 StartPos;
	public Vector3 BulletPos;
	bool CanShoot = true;
	bool IsShot = false;
	float Timer = 0;
	public GameObject Bullet;
	public GameObject PlayerTeamShip;
	public GameObject AttackRange;


	// Use this for initialization
	void Start () {
		StartPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		BulletPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Bullet = GetComponent <GameObject> ();
		PlayerTeamShip = GetComponent <GameObject> ();
	
	}

	void DamageTaken()
	{
		Health -= 1;
		if (Health <= 0)
			Destroy (this.gameObject);
	}

 	public float Lerp(float value1, float value2, float amount)
	{
		return (value1 + (value2 - value1) * amount);
	}

	void Shoot(GameObject PlayerTeamShip)
	{

		if (CanShoot) 
		{
				IsShot = true;
				if (IsShot == true && Timer > 2) 
				{

				CanShoot = false;
				Timer = 0;
				}
		}
	}

	void LerpToTarget(Collision c)
	{

		//N = (BulletPos.x - c.transform.position.x)/(BulletPos.y - c.transform.position.y);
	}


	// Detect for combat
	void DetectOthers()
	{
		//int LayerMask = 1 << 11;
		
		Collider[] hits = Physics.OverlapSphere(this.transform.position, 30.0f);
		
		// Detect unit and shoot if enemy
		for (int i = 0; i < hits.Length; i++)
		{
			if (hits[i].gameObject.tag == "PlayerUnit")
			{
				//Shoot ("PlayerUnit");


				//NextFire = Time.time + FireRate;
				//hits[i].gameObject.GetComponent<EnemyBasicUnit>().TakeDamage(5);
				//Shoot(hits[i]);
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
		Timer += Time.deltaTime;

		DetectOthers ();
	}
}
