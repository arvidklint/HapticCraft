using UnityEngine;
using System.Collections;

public class GameBoard : MonoBehaviour {

    public float hitDeltaTime = 1.0f;
    float timeSinceLastHit = 0;
    bool canMiss = true;

    public WhackAMole whackAMole;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        timeSinceLastHit += Time.deltaTime;
        if (timeSinceLastHit >= hitDeltaTime) {
            canMiss = true;
            timeSinceLastHit = 0;
        }
    }

    void OnTriggerEnter(Collider collider) {
        if(canMiss) {
            Debug.Log("Miss");
            canMiss = false;
            whackAMole.AddMiss();
        }
        
    }
}
