using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PointCounter : MonoBehaviour {
    public List<GameObject> numbers = new List<GameObject>();
    public WhackAMole whackAMole;

    GameObject firstNumber, secondNumber;

    int currentNumber = 0;
    int lastNumber = 0;

    // Use this for initialization
    void Start() {
        firstNumber = (GameObject)Instantiate(numbers[0], new Vector3(transform.position.x - 0.03f, transform.position.y, transform.position.z), transform.rotation);
        secondNumber = (GameObject)Instantiate(numbers[0], new Vector3(transform.position.x + 0.03f, transform.position.y, transform.position.z), transform.rotation);
        firstNumber.transform.localScale *= 0.7f;
        secondNumber.transform.localScale *= 0.7f;
    }

    // Update is called once per frame
    void FixedUpdate() {
        currentNumber = whackAMole.GetPoints();

        if (currentNumber != lastNumber) {
            SetNumber();
            lastNumber = currentNumber;
        }
    }

    void SetNumber() {
        List<int> ints = new List<int>();
        ints = GetIntArray(currentNumber);
        while (ints.Count <= 1) {
            ints.Insert(0, 0);
        }
        Destroy(firstNumber);
        Destroy(secondNumber);
        firstNumber = (GameObject)Instantiate(numbers[ints[0]], new Vector3(transform.position.x - 0.03f, transform.position.y, transform.position.z), transform.rotation);
        secondNumber = (GameObject)Instantiate(numbers[ints[1]], new Vector3(transform.position.x + 0.03f, transform.position.y, transform.position.z), transform.rotation);
        firstNumber.transform.localScale *= 0.7f;
        secondNumber.transform.localScale *= 0.7f;
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
