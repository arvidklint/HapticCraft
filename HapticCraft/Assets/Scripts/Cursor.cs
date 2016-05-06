using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Cursor : MonoBehaviour {

    public GameObject godObject;
    public GameObject tip;
    public SphereManipulator sm;
    public SphereCollider trigger;
    public List<Collider> colliderList = new List<Collider>();

    bool buttonStateChanged = false;
    bool buttonPressed = false;

    GameObject grabbedBlock;
    Collider grabbedBlockCollider;

    Vector3 diff;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        bool buttonState = sm.button_states[0];
        Debug.Log(buttonState + " " + buttonPressed + " " + buttonStateChanged);

        if (buttonState != buttonPressed) {
            buttonStateChanged = true;
        }

        if (buttonStateChanged && buttonState) {
            Debug.Log("Tryck");
            grabbedBlockCollider = colliderList[0];
            grabbedBlock = colliderList[0].gameObject;
            diff = grabbedBlock.transform.position - godObject.transform.position;
            grabbedBlock.transform.localPosition = diff;
            buttonStateChanged = false;
            buttonPressed = true;
        } else if (buttonStateChanged && !buttonState) {
            Debug.Log("släpp");
            buttonStateChanged = false;
            buttonPressed = false;
        }

        if (buttonPressed) {
            Debug.Log("Button pressed");
            grabbedBlock.GetComponent<FalconRigidBody>().MovePosition(godObject.transform.position + diff);
            //grabbedBlock.GetComponent<FalconRigidBody>().refreshShape();
        }
	}

    void OnTriggerEnter(Collider collider) {
        if (!colliderList.Contains(collider) && collider.gameObject.layer == 8) {
            colliderList.Add(collider);
        }
    }

    void OnTriggerExit(Collider collider) {
        if (colliderList.Contains(collider)) {
            colliderList.Remove(collider);
        }
    }
}
