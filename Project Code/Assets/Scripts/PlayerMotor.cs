using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour {

    public float personalSpace = 5;
	[SerializeField]
	private Camera cam;

	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float cameraRotationX = 0f;
	private float currentCameraRotationX = 0f;
	private Vector3 thrusterForce = Vector3.zero;

	[SerializeField]
	private float cameraRotationLimit = 85f;

	private Rigidbody rb;

	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}

	// Gets a mov vector
	public void Move(Vector3 _velocity)
	{
		velocity = _velocity;
	}

	public void Rotate(Vector3 _rotation)
	{
		rotation = _rotation;
	}

	public void RotateCamera(float _cameraRotationX)
	{
		cameraRotationX = _cameraRotationX;
	}

	public void ApplyThruster(Vector3 _thrusterForce)
	{
		thrusterForce = _thrusterForce;
	}

	// Run every Physics iteration
	void FixedUpdate()
	{
        //if(PersonalSpace() == false)
        //{
        //    PerformMovement();
        //}
		
        PerformMovement();
		PerformRotation ();
	}

	void PerformMovement ()
	{
		if (velocity != Vector3.zero) 
		{
			rb.MovePosition (transform.position + velocity * Time.fixedDeltaTime);
		}

		if (thrusterForce != Vector3.zero) 
		{
			rb.AddForce(thrusterForce * Time.fixedDeltaTime, ForceMode.Acceleration);
		}
	}

	void PerformRotation()
	{
		if(rotation != Vector3.zero)
		{
			rb.MoveRotation (rb.rotation * Quaternion.Euler(rotation));
		}

		if (cam != null) 
		{
			// Set our rotation and clmap it
			currentCameraRotationX -= cameraRotationX;
			currentCameraRotationX = Mathf.Clamp (currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

			// Apply our rotation to the transform of our camera
			cam.transform.localEulerAngles = new Vector3 (currentCameraRotationX, 0f, 0f);
		}
	}

    // This method does prevent getting to close to things but makes things choppy
    // Maybe modify
    bool PersonalSpace()
    {
        bool isPersonalSpace = false;
        RaycastHit _hit;

        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, personalSpace))
        {
            isPersonalSpace = true;
        }
        else{
            isPersonalSpace = false;
        }
        return isPersonalSpace;
    }
}
