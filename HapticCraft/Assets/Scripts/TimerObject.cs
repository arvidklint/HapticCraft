using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TimerObject : MonoBehaviour {

    public Timer timer;
    public List<GameObject> numbers = new List<GameObject>();

    GameObject firstNumber, secondNumber;


    int currentNumber = 60;
    int lastNumber = 0;

	// Use this for initialization
	void Start () {
        firstNumber = (GameObject)Instantiate(numbers[0], new Vector3(transform.position.x - 0.04f, transform.position.y, transform.position.z), transform.rotation);
        secondNumber = (GameObject)Instantiate(numbers[0], new Vector3(transform.position.x + 0.04f, transform.position.y, transform.position.z), transform.rotation);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        currentNumber = timer.GetIntTime();

        if (currentNumber != lastNumber) {
            SetNumber();
            lastNumber = currentNumber;
        }
	}

    void SetNumber() {
        List<int> ints = new List<int>();
        ints = GetIntArray(currentNumber);
        while(ints.Count <= 1) {
            ints.Insert(0, 0);
        }
        Destroy(firstNumber);
        Destroy(secondNumber);
        firstNumber = (GameObject)Instantiate(numbers[ints[0]], new Vector3(transform.position.x - 0.04f, transform.position.y, transform.position.z), transform.rotation);
        secondNumber = (GameObject)Instantiate(numbers[ints[1]], new Vector3(transform.position.x + 0.04f, transform.position.y, transform.position.z), transform.rotation);
    }

    List<int> GetIntArray(int num) {
        List<int> listOfInts = new List<int>();
        while (num > 0) {
            listOfInts.Add(num % 10);
            num = num / 10;
        }
        listOfInts.Reverse();
        return listOfInts;
    }
}
