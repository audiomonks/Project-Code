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
        if(door != null && door.tag == "Door")
        {
            if (buttonPressed && doorIsOpen == false)
            {
                Debug.Log("Open A Door");
                door.SetActive(false);
                doorIsOpen = true;
            }
            else if (buttonPressed == false && doorIsOpen)
            {
                Debug.Log("Close A Door");
                door.SetActive(true);
                doorIsOpen = false;
            }
        }

        if(door != null && door.tag == "Final Door" && ObjectsToCollect.allObjectsCollected)
        {
            if (buttonPressed && doorIsOpen == false)
            {
                Debug.Log("Open A Door");
                door.SetActive(false);
                doorIsOpen = true;
            }
            else if (buttonPressed == false && doorIsOpen)
            {
                Debug.Log("Close A Door");
                door.SetActive(true);
                doorIsOpen = false;
            }
        }
        else if(door != null && door.tag == "Final Door" && ObjectsToCollect.allObjectsCollected == false)
        {
            buttonPressed = false;
        }
    }
}
