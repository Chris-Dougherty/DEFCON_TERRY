using UnityEngine;
using System.Collections;


public class BasicTurret : MonoBehaviour {
	public int Health = 3;
	Vector3 StartPos;
	bool CanShoot = true;
	bool IsShot = false;
	float Timer = 0;

	public GameObject Bullet;
	public GameObject PlayerTeamShip;
	public GameObject AttackRange;


	// Use this for initialization
	void Start () {
		StartPos = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Bullet = GetComponent <GameObject> ();
	
	}

	void DamageTaken()
	{
		Health -= 1;
		if (Health <= 0)
			Destroy (this.gameObject);
	}
	void Shoot(GameObject PlayerTeamShip)
	{
		if (CanShoot) 
		{
				IsShot = true;
				if (IsShot == true && Timer > 2) 
				{
				Bullet.
				CanShoot = false;
				Timer = 0;
				}
		}
	}
	void HitTarget(Collision c)
	{
		if (c.gameObject.tag == "PlayerTeamShip") 		
			Destroy (Bullet.gameObject);
	}
	void InAttackRange(Collision d)
	{
		if (d.gameObject.tag == "AttackRange")
			Shoot ();
	}

	// Detect for combat
	void DetectOthers()
	{
		//int LayerMask = 1 << 11;
		
		Collider[] hits = Physics.OverlapSphere(this.transform.position, 30.0f);
		
		// Detect unit and shoot if enemy
		for (int i = 0; i < hits.Length; i++)
		{
			if (hits[i].gameObject.tag == "PlayerTeamShip")
			{
				Shoot ("PlayerTeamShip");


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
