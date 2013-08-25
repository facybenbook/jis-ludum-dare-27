using UnityEngine;
using System.Collections;

public class ManageAIPlayer : MonoBehaviour 
{
	public float thrustSpeed;
	public float thrustDrag;
	public float rotateSpeed;
	public float rotateDrag;
	public GameObject bulletPrefab;
	public GameObject shieldPrefab;
	
	private ManagePlayerState mps;
	
	// Use this for initialization
	void Start () 
	{
		mps = gameObject.GetComponent<ManagePlayerState>();
		if(!mps)
		{
			print("ManageAIPlayer: Couldn't get player state!");
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
	}
	
	
	public void ThrustAI(float normalizedMagnitude)
	{
		Mathf.Clamp(normalizedMagnitude, -1.0f, 1.0f);
		
		if(normalizedMagnitude > 0.2f)
		{
			rigidbody.AddRelativeForce(Vector3.forward * thrustSpeed * Time.deltaTime);
		}
		if(normalizedMagnitude < -0.2f)
		{
			rigidbody.AddRelativeForce(Vector3.forward * -thrustSpeed * 0.75f * Time.deltaTime);
		}
	}
	
	
	public void RotateAI(float normalizedMagnitude)
	{
		Mathf.Clamp(normalizedMagnitude, -1.0f, 1.0f);
		
		if(normalizedMagnitude > 0.2f)
		{
			rigidbody.AddRelativeTorque(Vector3.up * rotateSpeed * Time.deltaTime);
		}
		if(normalizedMagnitude < -0.2f)
		{
			rigidbody.AddRelativeTorque(Vector3.up * -rotateSpeed * Time.deltaTime);
		}
	}
	
	public void ShootAIBullet()
	{
		if(mps.GetAmmo() > 0)
		{
			GameObject newBullet = Instantiate(bulletPrefab, 
								               transform.position + transform.forward * 1.6f, 
								               transform.rotation) as GameObject;
			newBullet.transform.forward = transform.forward;
			mps.AmmoDec();
			mps.bulletsFired++;
			if(mps.bulletsFired > 25)
			{
				mps.bulletsFired = 0;
				mps.LoseApproval();
			}
		}
	}
	
	public void ShootAIShield()
	{
		GameObject newShield = Instantiate(shieldPrefab, 
					                       transform.position, 
					                       transform.rotation) as GameObject;
		newShield.GetComponent<KeepShieldInFront>().playerTransform = transform;
		mps.AmmoInc();
	}
	
	
}


