﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    [SerializeField]
    string MainMenuScene;

    bool isPaused;

    public GameObject PauseUI;
    public WinCondition winCondition;

	// Use this for initialization
	void Start () {
        isPaused = false;
        winCondition = GetComponent<WinCondition>();
        winCondition.OnRoundComplete += OnRoundCompleteHandler;
    }

	void Update () {
		if (Input.GetKeyDown("p") || Input.GetKeyDown("escape")) {
            TogglePause();
        }
        else if (Input.GetKeyDown("r")) {
            Restart();
        }
	}

    public void TogglePause() {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        PauseUI.SetActive(isPaused);
    }

    public void Restart() {
        if (isPaused) {
            TogglePause();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene(MainMenuScene);
    }

    public void OnRoundCompleteHandler(string msg)
    {
        Debug.Log(msg);
    }
}
