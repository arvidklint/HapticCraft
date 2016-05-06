using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    FalconSpringedBody fsb;
    Renderer renderer;

    bool active = false;

    public Material highlight;
    public Material neutral;

	// Use this for initialization
	void Start () {
        renderer = GetComponent<Renderer>();
        fsb = GetComponent<FalconSpringedBody>();
        fsb.springPos = transform.position;
	}
	
    public void setActive() {
        renderer.material = highlight;
        active = true;
    }

    public bool GetActive() {
        return active;
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 9) {
            renderer.material = neutral;
            active = false;
        }
    }
}
