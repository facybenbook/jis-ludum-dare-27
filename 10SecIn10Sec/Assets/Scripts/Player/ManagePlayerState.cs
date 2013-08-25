using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Credit to ivkoni for vector rotation
// http://forum.unity3d.com/threads/33215-Vector-rotation

public class ManagePlayerState : MonoBehaviour 
{
	public GameObject spiritPrefab;
	public bool offenseMode = true;
	
	private List<GameObject> listOfSpirits;
	private int health = ControlGame.MAX_HEALTH;
	private int approvalPoints = 0;
	private int ammo = 0;
	
	// Use this for initialization
	void Start () 
	{
		if(offenseMode)
		{
			ammo = ControlGame.START_AMMO;
		}
		else
		{
			ammo = 0;
		}
		
		for(int i = 0; i < 10; i++)
		{
			GameObject newSpirit = Instantiate(spiritPrefab, 
											   transform.position, 
											   transform.rotation) as GameObject;
			Quaternion newAngle = Quaternion.AngleAxis(36*i, Vector3.up);
			Vector3 newAngeVec = newAngle * Vector3.forward;
			newSpirit.transform.position = transform.position + newAngeVec * 2.0f;
			ManageSpiritState mss = newSpirit.GetComponent<ManageSpiritState>();
			mss.SetSpiritIndex(i);
			mss.SetAngleDisp(newAngeVec);
			mss.playerTransform = transform;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Cheat for switching mode.
		/*
		if(Input.GetKeyUp(KeyCode.O))
		{
			offenseMode = !offenseMode;
		}
		//*/
		
		
	}
	
	
	// ----- Accessors ----- //
	
	public int GetHealth()
	{
		return health;
	}
	
	public void HealthDec()
	{
		health--;
	}
	
	public void HealthInc()
	{
		health++;
	}
	
	public int GetApprovalPoints()
	{
		return approvalPoints;
	}
	
	public int GetAmmo()
	{
		return ammo;
	}
	
	public void AmmoInc()
	{
		ammo++;
	}
	
	public void AmmoDec()
	{
		ammo--;
		if(ammo < 0)
		{
			ammo = 0;
		}
	}
}
