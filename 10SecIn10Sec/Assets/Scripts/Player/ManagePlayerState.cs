using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Credit to ivkoni for vector rotation
// http://forum.unity3d.com/threads/33215-Vector-rotation

public class ManagePlayerState : MonoBehaviour 
{
	public GameObject spiritPrefab;
	public GameObject preLabel;
	public bool offenseMode = true;
	public Material matOffense;
	public Material matDefense;
	public Material matWhiteL;
	public Material matBlackL;
	public bool labeledBlack = false;
	public bool labelChosen = false;
	
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
			gameObject.renderer.material = matOffense;
		}
		else
		{
			ammo = 0;
			gameObject.renderer.material = matDefense;
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
			swapState();
		}
		//*/
		
		if(labelChosen)
		{
			labelChosen = false;
			if(labeledBlack)
			{
				preLabel.renderer.material = matBlackL;
			}
			else
			{
				preLabel.renderer.material = matWhiteL;
			}
		}
		
	}
	
	public void swapState()	
	{
		offenseMode = !offenseMode;
		
		// Starting offense mode
		if(offenseMode)
		{
			gameObject.renderer.material = matOffense;
		}
		
		// Starting defense mode
		else
		{
			gameObject.renderer.material = matDefense;
			ammo = 0;
		}
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
	
	public void GainApproval()
	{
		if(approvalPoints < 10)
		{
			approvalPoints++;
		}
	}
	
	public void LoseApproval()
	{
		if(approvalPoints > 0)
		{
			approvalPoints--;
		}
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
