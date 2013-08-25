using UnityEngine;
using System.Collections;

public class ManageAIPlayer : MonoBehaviour 
{
	public enum eAIStates
	{
		ChaseRelic,
		ChaseHealth,
		ShootLaser,
		ShootShield
	}
	
	public float thrustSpeed;
	public float thrustDrag;
	public float rotateSpeed;
	public float rotateDrag;
	public GameObject bulletPrefab;
	public GameObject shieldPrefab;
	public GameObject specialBulletPrefab;
	public GameObject theOpponent;
	
	public bool relicArrived = false;
	public bool healthArrived = false;
	
	//private ManagePlayerState opponentsManager;
	private ManagePlayerState mps;
	private bool inOffenseMode = false;
	private bool offenseOrDefenseJustChanged = false;
	private eAIStates currentAIState;
	
	// Use this for initialization
	void Start () 
	{
		mps = gameObject.GetComponent<ManagePlayerState>();
		if(!mps)
		{
			print("ManageAIPlayer: Couldn't get player state!");
		}
		//opponentsManager = theOpponent.GetComponent<ManagePlayerState>();
		
		inOffenseMode = mps.offenseMode;
		
		if(inOffenseMode)
		{
			currentAIState = eAIStates.ShootLaser;
		}
		else
		{
			currentAIState = eAIStates.ShootShield;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(thrustDrag < 0)
			thrustDrag = 0;
		if(rotateDrag < 0)
			rotateDrag = 0;
		
		rigidbody.drag = thrustDrag;
		rigidbody.angularDrag = rotateDrag;
		
		
		// ---------- AI State Changers ----------- //
		
		if(healthArrived)
		{
			healthArrived = false;
			
			// DETERMINE IF TO CHASE HEALTH
			int currHealth = mps.GetHealth();
			
			if(currHealth <= 50)
			{
				currentAIState = eAIStates.ChaseHealth;
			}
		}
		
		if(relicArrived)
		{
			relicArrived = false;
			
			// DETERMINE IF TO CHASE RELIC
			float currHealth = mps.GetHealth();
			
			if(currHealth > 50)
			{
				currentAIState = eAIStates.ChaseRelic;
			}
		}
		
		
		if(offenseOrDefenseJustChanged)
		{
			offenseOrDefenseJustChanged = false;
			
			// DETERMINE IF TO FIRE TO DEFEND
			if(inOffenseMode)
			{
				currentAIState = eAIStates.ShootLaser;
			}
			else
			{
				currentAIState = eAIStates.ShootShield;
			}
		}
		
		// ---------- AI State Implementers ------- //
		
		//ConstantlyFaceTarget(theOpponent);
		switch(currentAIState)
		{
			case eAIStates.ChaseHealth:
				ChaseHealth(); break;
			case eAIStates.ChaseRelic:
				ChaseRelic(); break;
			case eAIStates.ShootLaser:
				ShootLaser(); break;
			case eAIStates.ShootShield:
				ShootShield(); break;
		}
		
	}
	
	
	public void ThrustAI(float normalizedMagnitude)
	{
		Mathf.Clamp(normalizedMagnitude, -1.0f, 1.0f);
		
		if(normalizedMagnitude > 0.2f)
		{
			rigidbody.AddRelativeForce(Vector3.forward * thrustSpeed * Time.deltaTime);
		}
		if(normalizedMagnitude < -0.2f)
		{
			rigidbody.AddRelativeForce(Vector3.forward * -thrustSpeed * 0.75f * Time.deltaTime);
		}
	}
	
	public void RotateAI(float normalizedMagnitude)
	{
		Mathf.Clamp(normalizedMagnitude, -1.0f, 1.0f);
		
		if(normalizedMagnitude > 0.2f)
		{
			rigidbody.AddRelativeTorque(Vector3.up * rotateSpeed * Time.deltaTime);
		}
		if(normalizedMagnitude < -0.2f)
		{
			rigidbody.AddRelativeTorque(Vector3.up * -rotateSpeed * Time.deltaTime);
		}
	}
	
	public void ShootAIBullet()
	{
		if(mps.GetAmmo() > 0)
		{
			GameObject newBullet;
			if(mps.isInSpecialMode())
			{
				newBullet = Instantiate(specialBulletPrefab, 
									    transform.position + transform.forward * 3.2f, 
					                    transform.rotation) as GameObject;
			}
			else
			{
				newBullet = Instantiate(bulletPrefab, 
									    transform.position + transform.forward * 1.6f, 
					                    transform.rotation) as GameObject;
			}
			newBullet.transform.forward = transform.forward;
			mps.AmmoDec();
			mps.bulletsFired++;
			if(mps.bulletsFired > 50)
			{
				mps.bulletsFired = 0;
				mps.LoseApproval();
			}
		}
	}
	
	public void ShootAIShield()
	{
		if(! (mps.isInSpecialMode()) )
		{
			GameObject newShield = Instantiate(shieldPrefab, 
						                       transform.position, 
						                       transform.rotation) as GameObject;
			newShield.GetComponent<KeepShieldInFront>().playerTransform = transform;
			mps.AmmoInc();
		}	
	}
	
	public void SwapAIState()
	{
		inOffenseMode = !inOffenseMode;
		
		offenseOrDefenseJustChanged = true;
	}
	
	// ------- AI Exclusive Stuff -----------//
	//=======================================//
	
	
	private void ChaseTarget(GameObject theTarget)
	{
		// TBI (to be implemented)
	}
	
	private void ConstantlyFaceTarget(GameObject theTarget)
	{
		transform.LookAt(theTarget.transform);
	}
	
	
	// ------------ Update Loop AI Plans --------------//
	//=================================================//
	
	private void ChaseHealth()
	{
		print("Chase Health not implemented");
	}
	
	private void ChaseRelic()
	{
		print("Chase Relic not impemented");
	}
	
	private void ShootLaser()
	{
		print("Shoot Laser not implemented");
	}
	
	private void ShootShield()
	{
		print("Shoot Shield not implemented");
	}
}


