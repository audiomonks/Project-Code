using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFrameRate : MonoBehaviour
{

	public int Target = 300;
	// Use this for initialization
	void Start ()
	{
		QualitySettings.vSyncCount = 0;
		//Application.targetFrameRate = Target;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = Target;
	}
}