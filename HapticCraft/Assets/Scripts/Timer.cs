using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    float timeLeft = 0;
    bool running = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(running) {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0) {
                timeLeft = 0;
                running = false;
            }
        }
	}

    public void SetTimer(float time) {
        running = false;
        timeLeft = time;
    }

    public void StartTimer() {
        running = true;
    }

    public void StopTimer() {
        running = false;
    }

    public int GetIntTime() {
        return (int)timeLeft;
    }

    public bool IsRunning() {
        return running;
    }
    
    public bool isFinished() {
        return !running;
    }
}
