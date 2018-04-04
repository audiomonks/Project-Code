using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public GameObject GameOverUI;

	private void OnTriggerEnter(Collider other)
	{
        if(ObjectsToCollect.allObjectsCollected)
        {
            SlowWin();
        }
	}

    public void SlowWin()
    {
        Debug.Log("SlowWin");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameOverUI.SetActive(true);
        Time.timeScale = .25f;
    }
}
