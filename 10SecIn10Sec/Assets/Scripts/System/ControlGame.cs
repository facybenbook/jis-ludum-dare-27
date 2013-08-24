using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Credit to lhk for increment time counter
// http://answers.unity3d.com/questions/22252/incrementing-by-x-per-second.html

public class ControlGame : MonoBehaviour 
{
	[HideInInspector] public List<GameObject> listOfPlayers;
	private static GameObject m_instance;
	public static float currTime = 10.0f;
	private static double realTime = 0.0;
	
	// Use this for initialization
	void Start () 
	{
		// There can only be one controller
		if(m_instance == null)
		{
			m_instance = gameObject;
		}
		else
		{
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		IncrementTime();
	}
	
	// For drawing gizmos
	void OnDrawGizmos()
	{
		
	}
	
	// Registers a player to the controller
	public static void AddToList(GameObject go)
	{
		// If the singeton instance was assigned...
		if(m_instance)
		{
			// Add the player to the list of players
			if(go.CompareTag("Player"))
			{
				(m_instance.GetComponent<ControlGame>()).listOfPlayers.Add(go);
			}
			else
			{
				print("ControlGame: Trying to add a non-Player!");
			}
		}
		else
		{
			print("ControlGame: m_instance undefined!");
		}
	}
	
	private void IncrementTime()
	{
		//print(currTime);
		realTime += (double) Time.deltaTime;
		if(realTime > 1.0)
		{
			realTime -= 1.0;
			currTime--;
			if(currTime < 1.0f)
			{
				currTime = 10.0f;
			}
			
		}
	}
}
