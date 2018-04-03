using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool buttonPressed = false;
    public bool doorIsOpen = false;

    [SerializeField]
    private GameObject door;

	// Update is called once per frame
	void Update () 
    {
        OpenADoor();
	}

    private void OpenADoor()
    {
        if(buttonPressed && doorIsOpen == false)
        {
            Debug.Log("Open A Door");
            door.SetActive(false);
            doorIsOpen = true;
        }
        else if(buttonPressed == false && doorIsOpen == true)
        {
            Debug.Log("Close A Door");
            door.SetActive(true);
            doorIsOpen = false;
        }
    }
}
