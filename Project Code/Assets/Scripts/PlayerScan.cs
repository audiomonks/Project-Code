using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScan : MonoBehaviour {

    public static bool isZoomActive = false;
    public static bool hasACode = false;

    public static string buttonName;
    public static string cameraName;

    [SerializeField]
    private LayerMask mask;

	public Camera cam;
	public float range = 50f;

	private const string INTERACTABLE = "Interactable";

	void Update () 
	{
        // Button
        if (Input.GetMouseButtonUp(0))
        {
            ButtonPress();
        }

        if (Input.GetButtonDown("FireX"))
        {
            ButtonPress();
        }

        // Grabbable
        if (Input.GetMouseButtonUp(0))
        {
            Grab();
        }

        if (Input.GetButtonDown("FireX"))
        {
            Grab();
        }
	}

	void ButtonPress()
	{
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range, mask)) 
		{
            // Button
            if(hit.collider.tag == "Button")
            {
                hit.collider.GetComponent<OpenDoor>().buttonPressed = !hit.collider.GetComponent<OpenDoor>().buttonPressed;
            }
		}
	}

    void Grab()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range, mask))
        {
            // Grabbable
            if (hit.collider.tag == "Grabbable")
            {
                hit.collider.GetComponent<MoveObject>().isHolding = !hit.collider.GetComponent<MoveObject>().isHolding;
            }
        }
    }
}
