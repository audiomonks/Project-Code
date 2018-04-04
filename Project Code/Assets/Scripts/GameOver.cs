using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public static bool gameIsWon = false;
    public GameObject GameOverUI;
    public GameObject pauseMenu;

	private void OnTriggerEnter(Collider other)
	{
        if(ObjectsToCollect.allObjectsCollected)
        {
            Win();
        }
	}

    public void Win()
    {
        gameIsWon = true;
        Debug.Log("SlowWin");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
