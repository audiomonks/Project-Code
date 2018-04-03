using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasACode : MonoBehaviour {
    
    [SerializeField]
    PlayerScan scan;
    [SerializeField]
    private GameObject knob;

    public float rate = 10f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetButtonDown("Fire1") && PlayerScan.hasACode && knob.transform.tag == "Interactable")
        {
            RotateKnob90();
        }
	}

    void SpinObject()
    {
        knob.transform.Rotate(Vector3.right * Time.deltaTime * rate);
    }

    void RotateKnob90()
    {
        knob.transform.Rotate(Vector3.up, 90);
    }
}
