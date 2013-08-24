using UnityEngine;
using System.Collections;

public class ShootBullet : MonoBehaviour 
{
	public GameObject bulletPrefab;
	private ManagePlayerState mps;
	
	// Use this for initialization
	void Start () 
	{
		mps = gameObject.GetComponent<ManagePlayerState>();
		if(!mps)
		{
			print("ShootBullet: Couldn't get player state!");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton5))
		{
			if(mps.offenseMode)
			{
				Instantiate(bulletPrefab, 
							transform.position + transform.forward * 1.1f, 
							transform.rotation);
			}
			else
			{
				print("SHIELD!");
			}
			
		}
	}
}
