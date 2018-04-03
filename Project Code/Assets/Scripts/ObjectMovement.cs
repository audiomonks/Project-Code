using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    public bool hasRotation = false;
    public int speedRate = 100;

	// Update is called once per frame
	void FixedUpdate () 
    {
        if(hasRotation)
        {
            Spin();
        }
	}

    void Spin()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speedRate);
    }
}
