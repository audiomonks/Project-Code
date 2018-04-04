using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnloadUnusedAssets : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    #if UNITY_EDITOR

    [UnityEditor.MenuItem("Assets/Unload Assets")]
    static void UnloadAssets()
    {
        Resources.UnloadUnusedAssets();
    }

    #endif
}
