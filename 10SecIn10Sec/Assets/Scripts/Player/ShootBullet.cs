using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour 
{
	public GameObject bulletPrefab;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
		{
			Instantiate(bulletPrefab, 
						transform.position + transform.forward * 1.1f, 
						transform.rotation);
			
		}
	}
}
