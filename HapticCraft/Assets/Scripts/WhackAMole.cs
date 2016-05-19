using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WhackAMole : MonoBehaviour {

    public List<Button> buttons = new List<Button>();
    public StartButton startButton;

    float timeSinceLastActivation = 0;
    float timeBetweenActivation = 2;
    float timeSinceStart = 0;
    public float difficultyScaling = 2;
    int difficultyLevel = 1;
    public float timeBetweenNextDifficulty = 20;
    int totalPoints = 0;
    int totalMisses = 0;
    float countDownTimer = 4;
    int lastCountDownNumber = 4;

    public List<GameObject> countDownNumbers = new List<GameObject>();
    public Transform countDownPosition;

    bool gameRunning = false;
    bool countDown = false;
    bool gameReseted = false;

    bool buttonActive = false;

    public Timer timer;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	    if(gameRunning) {
            RunGame();
        } else if (countDown) {
            CountDown();
        }
	}

    void RunGame() {
        if(!buttonActive) {
            ActivateRandomButton();
        }

        if(timer.isFinished() && !gameReseted) {
            for(int i = 0; i < buttons.Count; i++) {
                buttons[i].Deactivate();
            }
            buttonActive = false;
            startButton.setActive();
            gameReseted = true;
            gameRunning = false;
        }
    }

    void CountDown() {
        countDownTimer -= Time.deltaTime;
        if((int)countDownTimer < lastCountDownNumber) {
            Instantiate(countDownNumbers[(int)countDownTimer], countDownPosition.position, Quaternion.identity);
            lastCountDownNumber = (int)countDownTimer;
        }

        if((int)countDownTimer == 0) {
            countDown = false;
            gameRunning = true;
            timer.SetTimer(20);
            timer.StartTimer();
        }
    }

    void ActivateRandomButton() {
        int randomInt = Random.Range(0, buttons.Count);
        buttons[randomInt].setActive();
        buttonActive = true;
    }

    public void StartGame() {
        Debug.Log("Start Game");
        gameReseted = false;
        countDown = true;
        gameRunning = false;
        lastCountDownNumber = 4;
        countDownTimer = 4f;
        totalPoints = 0;
        totalMisses = 0;
    }

    public void ButtonPushed() {
        if(timer.IsRunning()) {
            totalPoints++;
            buttonActive = false;
        }
    }

    public void AddMiss() {
        if(timer.IsRunning()) {
            totalMisses++;
        }
    }

    public int GetMisses() {
        return totalMisses;
    }

    public int GetPoints() {
        return totalPoints;
    }
}
