using UnityEngine;
using System.Collections;

public class RegisterWithController : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
	{
		if(gameObject.CompareTag("Player"))
		{
			// Register gameobject to controller
			ControlGame.AddToList(gameObject);
		}
		else
		{
			print("RegisterWithController: Only objects tagged with \"Player\" can be registered!");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
