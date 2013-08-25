using UnityEngine;
using System.Collections;

public class SteerPlayer : MonoBehaviour 
{
	public float thrustSpeed;
	public float thrustDrag;
	public float rotateSpeed;
	public float rotateDrag;
	
	private ManagePlayerState mps;
	
	// Use this for initialization
	void Start () 
	{
		mps = gameObject.GetComponent<ManagePlayerState>();
		if(!mps)
		{
			print("SteerPlayer: Couldn't get player state!");
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(thrustDrag < 0)
			thrustDrag = 0;
		if(rotateDrag < 0)
			rotateDrag = 0;
		
		rigidbody.drag = thrustDrag;
		rigidbody.angularDrag = rotateDrag;
		
		// Thrust forward or backward
		if(Input.GetAxis("Vertical") > 0.2f)
		{
			rigidbody.AddRelativeForce(Vector3.forward * thrustSpeed * Time.deltaTime);
		}
		if(Input.GetAxis("Vertical") < -0.2f)
		{
			rigidbody.AddRelativeForce(Vector3.forward * -thrustSpeed * 0.75f * Time.deltaTime);
		}
		
		// Turn clockwise or counterclockwise
		if(Input.GetAxis("Horizontal") > 0.2f)
		{
			rigidbody.AddRelativeTorque(Vector3.up * rotateSpeed * Time.deltaTime);
		}
		if(Input.GetAxis("Horizontal") < -0.2f)
		{
			rigidbody.AddRelativeTorque(Vector3.up * -rotateSpeed * Time.deltaTime);
		}
	}
	
	// For drawing on the GUI
	void OnGUI()
	{
		//GUI.Label (new Rect (0,0,100,50), "This is the text string for a Label Control");
	}
}
