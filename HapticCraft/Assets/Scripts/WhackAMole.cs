using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WhackAMole : MonoBehaviour {

    public List<Button> buttons = new List<Button>();

    float timeSinceLastActivation = 0;
    float timeBetweenActivation = 2;
    float timeSinceStart = 0;
    public float difficultyScaling = 2;
    int difficultyLevel = 1;
    public float timeBetweenNextDifficulty = 20;

    bool gameRunning = false;

	// Use this for initialization
	void Start () {
        gameRunning = true;
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameRunning) {
            RunGame();
        }
	}

    void RunGame() {
        if (timeSinceLastActivation > timeBetweenActivation) {
            ActivateRandomButton();
            if (timeSinceStart > timeBetweenNextDifficulty * difficultyLevel) {
                difficultyLevel++;
                timeBetweenActivation /= difficultyScaling;
            }
            timeSinceLastActivation = 0;
        } else {
            timeSinceLastActivation += Time.deltaTime;
            timeSinceStart += Time.deltaTime;
        }
    }

    void ActivateRandomButton() {
        int randomInt = Random.Range(0, buttons.Count);
        buttons[randomInt].setActive();
    }

    public void StartGame() {
        gameRunning = true;
    }
}
