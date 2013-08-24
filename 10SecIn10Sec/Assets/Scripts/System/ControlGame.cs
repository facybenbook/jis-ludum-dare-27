using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ControlGame : MonoBehaviour 
{
	[HideInInspector] public List<GameObject> listOfPlayers;
	private static GameObject m_instance;
	
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
}
