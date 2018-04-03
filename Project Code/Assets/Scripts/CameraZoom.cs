using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private new GameObject gameObject;
    [SerializeField]
    private Canvas canvas;

    void Start()
    {
        cam.enabled = false;
    }

    void Update()
    {
        
        if (PlayerScan.isZoomActive && PlayerScan.cameraName == cam.name)
        {
            cam.enabled = true;
            canvas.enabled = false;
        }
        if (PlayerScan.isZoomActive == false && PlayerScan.cameraName == cam.name)
        {
            cam.enabled = false;
            canvas.enabled = true;
        }
    }
}
