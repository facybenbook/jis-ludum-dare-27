using UnityEngine;
using System.Collections;

public class DropSound : MonoBehaviour 
{
	public AudioClip soundToPlay;
	
	// Use this for initialization
	void Start () 
	{
		gameObject.AddComponent<AudioSource>();
		audio.clip = soundToPlay;
		
		audio.Play();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	void OnDrawGizmos() {}
}
