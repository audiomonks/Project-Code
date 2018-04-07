using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

	public GameObject item;
	public GameObject tempParent;
    public Transform OriginalParent;
    public Transform guide;
    public Rigidbody rigidbody;
    public bool isMovable = false;
    public bool isHolding = false;

	void Start () 
    {
        item.GetComponent<Rigidbody>().useGravity = true;
        OriginalParent = item.transform.parent;
        rigidbody = GetComponent<Rigidbody>();
	}

    void Update()
    {
        if (isHolding)
        {
            item.GetComponent<Rigidbody>().useGravity = false;
            item.GetComponent<Rigidbody>().isKinematic = true;
            //item.transform.position = guide.transform.position;
            rigidbody.transform.position = guide.transform.position;
            rigidbody.transform.rotation = guide.transform.rotation;

            item.transform.parent = tempParent.transform;
        }
        if (isHolding == true)
        {
            item.GetComponent<Rigidbody>().useGravity = true;
            item.GetComponent<Rigidbody>().isKinematic = false;
            item.transform.parent = OriginalParent;

            //item.transform.position = guide.transform.position;

            rigidbody.transform.position = guide.transform.position;
        }
    }
}
