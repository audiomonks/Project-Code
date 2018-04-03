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

    void Start()
    {

    }
	void Update () 
	{
        IsInteractable();
	}

	void IsInteractable()
	{
		RaycastHit hit;
		if (Physics.Raycast (cam.transform.position, cam.transform.forward, out hit, range, mask)) 
		{
            // Button
            if(Input.GetMouseButtonUp(0) && hit.collider.tag == "Button")
            {
                hit.collider.GetComponent<OpenDoor>().buttonPressed = !hit.collider.GetComponent<OpenDoor>().buttonPressed;
            }

            if (Input.GetButtonDown("FireX") && hit.collider.tag == "Button")
            {
                hit.collider.GetComponent<OpenDoor>().buttonPressed = !hit.collider.GetComponent<OpenDoor>().buttonPressed;
            }

            // Grabbable
            if (Input.GetMouseButtonUp(0) && hit.collider.tag == "Grabbable")
            {
                Debug.Log("Grabable Player Scan");
                hit.collider.GetComponent<MoveObject>().isHolding = !hit.collider.GetComponent<MoveObject>().isHolding;
            }

            if (Input.GetButtonDown("FireX") && hit.collider.tag == "Grabbable")
            {
                hit.collider.GetComponent<MoveObject>().isHolding = !hit.collider.GetComponent<MoveObject>().isHolding;
            }

   //         bool _isZoomable = hit.collider.GetComponent<ItemManager>().isZoomable;
   //         bool _hasACode = hit.collider.GetComponent<ItemManager>().hasACode;
   //         cameraName = hit.collider.GetComponent<ItemManager>().name + "_Cam";

   //         if (_isZoomable) 
			//{
   //             IsZoomable(hit);
			//}
   //         if (_hasACode) 
			//{
   //             hasACode = true;
			//}
		}
	}

 //   void IsZoomable(RaycastHit _hit)
	//{
 //       if (Input.GetButtonDown("Fire1") && isZoomActive == false)
 //       {
 //           isZoomActive = true;
 //       }

 //       else if (Input.GetButtonDown("Fire1") && isZoomActive)
 //       {
 //           isZoomActive = false;
 //       }
	//}
}
