using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbable : MonoBehaviour {
	
    public bool isHolding = false;

    [SerializeField]
    private GameObject gameObjectCube;
    [SerializeField]
    private GameObject face;
    [SerializeField]
    private Rigidbody rb;

    RaycastHit hit;
    public int speedRate = 100;
    public bool hasSpin = false;

	private void Start()
	{
        isHolding = false;
	}

	void Update () 
    {
        if(isHolding)
        {
            SnapToPlayer();
            DisableComponents();
        }

        if(isHolding)
        {
            EnableComponents();
        }

        if (hasSpin)
        {
            SpinObject();
        }
	}

    void SnapToPlayer()
    {
        // Snaps to player but doesn't stay in front when turns.
        //Vector3 playerPosition = face.transform.position;
        gameObjectCube.transform.position = face.transform.position;

        // Turns object amount player turns
        Quaternion grabbaleRotation = face.transform.rotation;
        gameObjectCube.transform.rotation = grabbaleRotation;

    }

    void SpinObject()
    {
        gameObjectCube.transform.Rotate(Vector3.up * Time.deltaTime * speedRate);
    }

    void DisableComponents()
    {
        rb.freezeRotation = true;
    }

    void EnableComponents()
    {
        rb.freezeRotation = false;
    }
}
