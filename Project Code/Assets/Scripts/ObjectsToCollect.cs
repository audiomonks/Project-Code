using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToCollect : MonoBehaviour {

    public static int objects;

	private void Awake()
    {
        objects = 0;
	}

	private void Start()
	{
        objects++;
	}
	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "Player")
        {
            objects--;
            gameObject.SetActive(false);
        }
	}
}
