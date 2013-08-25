using UnityEngine;
using System.Collections;

public class DefinePowerup : MonoBehaviour 
{
	public enum ePowerupType
	{
		Health,
		Relic
	}
	
	public ePowerupType thePowerupType = ePowerupType.Health;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	
	public ePowerupType GetTypeOfPowerup()
	{
		return thePowerupType;
	}
	
		
	
}
