using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountObjects : MonoBehaviour {

    public string nextLevel;
    public GameObject objectToDestroy;
    public GameObject objectUI;

	void Start () 
	{
        objectUI = GameObject.Find("ObjectNumbers");
	}
	
	void Update () 
	{
        objectUI.GetComponent<Text>().text = ObjectsToCollect.objects.ToString();

        if (ObjectsToCollect.objects == 0)
        {
            //Application.LoadLevel("Next Level");
            objectUI.GetComponent<Text>().text = "All objects collected";
            Destroy(objectToDestroy);
            //StartCoroutine(DisplayAllObjectsCollected());
        }
		
	}

    //IEnumerator DisplayAllObjectsCollected()
    //{
    //    objectUI.GetComponent<Text>().text = "All objects collected";
    //    yield return new WaitForSeconds(5);
    //    objectUI.GetComponent<Text>().text = "";
    //}
}
