using UnityEngine;
using System.Collections;

public class MoveProjectile : MonoBehaviour 
{
	public float bulletSpeed;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(Vector3.forward * bulletSpeed * Time.deltaTime);
	}
}
