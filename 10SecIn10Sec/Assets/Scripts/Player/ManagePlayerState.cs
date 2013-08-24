using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Credit to ivkoni for vector rotation
// http://forum.unity3d.com/threads/33215-Vector-rotation

public class ManagePlayerState : MonoBehaviour 
{
	public GameObject spiritPrefab;
	public bool offenseMode = true;
	
	private int health = 0;
	private List<GameObject> listOfSpirits;
	
	// Use this for initialization
	void Start () 
	{
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
	
	}
	
	public int GetHealth()
	{
		return health;
	}
}
