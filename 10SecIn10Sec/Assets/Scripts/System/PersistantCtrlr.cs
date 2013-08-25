using UnityEngine;
using System.Collections;

public class PersistantCtrlr : MonoBehaviour 
{
	public bool lWhitePlayerWon = false;
	
	// Constructor
	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
	
	// For Gizmos
	void OnDrawGizmos() {}
}
