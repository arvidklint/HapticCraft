using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

    FalconSpringedBody fsb;
    Renderer renderer;

    bool active = false;

    public Material highlight;
    public Material neutral;

    public WhackAMole whackAMole;

    // Use this for initialization
    void Start() {
        renderer = GetComponent<Renderer>();
        fsb = GetComponent<FalconSpringedBody>();
        fsb.springPos = transform.position;
        setActive();
    }

    public void setActive() {
        renderer.material = highlight;
        active = true;
    }

    public bool GetActive() {
        return active;
    }

    void OnTriggerEnter(Collider other) {
        Debug.Log("Collider");
        if (other.gameObject.layer == 9) {
            if (active) {
                renderer.material = neutral;
                active = false;
                whackAMole.StartGame();
            }
        }
    }
}
